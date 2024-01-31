using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using Mapbox.Directions;
using Mapbox.Unity.MeshGeneration.Factories;
using System.Collections.Generic;
using Mapbox.Unity;
using UnityEngine.SceneManagement;
using ARLocation.MapboxRoutes;
using ARLocation;
using System.Collections;
using JetBrains.Annotations;
using System;
using Location = ARLocation.Location;

public class RouteMaker : MonoBehaviour
{
    public enum LineType
    {
        Route,
        NextTarget
    }

    public string MapboxToken = "pk.eyJ1IjoiZG1iZm0iLCJhIjoiY2tyYW9hdGMwNGt6dTJ2bzhieDg3NGJxNyJ9.qaQsMUbyu4iARFe0XB2SWg";
    public GameObject RouteContainer;
    public Camera MapboxMapCamera;
    public MapboxRoute MapboxRoute;
    public AbstractRouteRenderer RoutePathRenderer;
    public AbstractRouteRenderer NextTargetPathRenderer;
    public Texture RenderTexture;
    public Mapbox.Unity.Map.AbstractMap Map;
    [Range(100, 800)]
    public int MapSize = 400;
    public int MinimapLayer;
    public Material MinimapLineMaterial;
    public float BaseLineWidth = 2;
    public float MinimapStepSize = 0.5f;

    private AbstractRouteRenderer currentPathRenderer => PathRendererType == LineType.Route ? RoutePathRenderer : NextTargetPathRenderer;

    public string monumentoActivo;

    string apiError;


    public int mapZoom;

    public ARLocation.Location location = new ARLocation.Location();

    public LineType PathRendererType
    {
        get => PathRendererType;
        set
        {
            if (value != PathRendererType)
            {
                currentPathRenderer.enabled = false;
                PathRendererType = value;
                currentPathRenderer.enabled = true;
                MapboxRoute.RoutePathRenderer = currentPathRenderer;

            }
        }
    }


    void OnGUI()
    {
        drawMap();
    }

    void Start()
    {
        

        NextTargetPathRenderer.enabled = false;
        RoutePathRenderer.enabled = false;
        ARLocationProvider.Instance.OnEnabled.AddListener(onLocationEnabled);
        Map.OnUpdated += OnMapRedrawn;

        mapZoom = 10;
    }

    private void OnMapRedrawn()
    {
        // Debug.Log("OnMapRedrawn");
        if (currentResponse != null)
        {
            buildMinimapRoute(currentResponse);
        }
    }

    private void onLocationEnabled(ARLocation.Location location)
    {
        Map.SetCenterLatitudeLongitude(new Mapbox.Utils.Vector2d(location.Latitude, location.Longitude));
        // Map.SetZoom(18);
        Map.UpdateMap();
    }

    void drawMap()
    {
        var tw = RenderTexture.width;
        var th = RenderTexture.height;

        var scale = MapSize / th;
        var newWidth = scale * tw;
        var x = Screen.width / 2 - newWidth / 2;
        float border;
        if (x < 0)
        {
            border = -x;
        }
        else
        {
            border = 0;
        }

        Map.UpdateMap();

        // GUI.DrawTexture(new Rect(x, Screen.height - MapSize, newWidth, MapSize), RenderTexture, ScaleMode.ScaleAndCrop);

        // var newZoom = GUI.HorizontalSlider(new Rect(0, Screen.height - 60, Screen.width, 60), Map.Zoom, 10, 22);

        // if (newZoom != Map.Zoom)
        // {
        //     Map.SetZoom(newZoom);
        //     Map.UpdateMap();
        //     // buildMinimapRoute(currentResponse);
        // }
    }



    public void StartRoute(Location dest)
    {


        if (ARLocationProvider.Instance.IsEnabled)
        {
            generateRoute(ARLocationProvider.Instance.CurrentLocation.ToLocation());
        }
        else
        {
            ARLocationProvider.Instance.OnEnabled.AddListener(generateRoute);
        }
    }

    public void EndRoute()
    {
        ARLocationProvider.Instance.OnEnabled.RemoveListener(generateRoute);

        RouteContainer.SetActive(false);
    }


    private GameObject minimapRouteGo;
    private RouteResponse currentResponse;

    private void buildMinimapRoute(RouteResponse res)
    {
        var geo = res.routes[0].geometry;
        var vertices = new List<Vector3>();
        var indices = new List<int>();

        var worldPositions = new List<Vector2>();

        foreach (var p in geo.coordinates)
        {
            /* var pos = Mapbox.Unity.Utilities.Conversions.GeoToWorldPosition(
                    p.Latitude,
                    p.Longitude,
                    Map.CenterMercator,
                    Map.WorldRelativeScale
                    ); */

            // Mapbox.Unity.Utilities.Conversions.GeoToWorldPosition
            var pos = Map.GeoToWorldPosition(new Mapbox.Utils.Vector2d(p.Latitude, p.Longitude), true);
            worldPositions.Add(new Vector2(pos.x, pos.z));
            // worldPositions.Add(new Vector2((float)pos.x, (float)pos.y));
        }

        if (minimapRouteGo != null)
        {
            minimapRouteGo.Destroy();
        }

        minimapRouteGo = new GameObject("minimap route game object");
        minimapRouteGo.layer = MinimapLayer;

        var mesh = minimapRouteGo.AddComponent<MeshFilter>().mesh;

        var lineWidth = BaseLineWidth * Mathf.Pow(2.0f, Map.Zoom - 18);
        LineBuilder.BuildLineMesh(worldPositions, mesh, lineWidth);

        var meshRenderer = minimapRouteGo.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = MinimapLineMaterial;
    }


    Vector3 lastCameraPos;
    void Update()
    {

        var cameraPos = Camera.main.transform.position;

        var arLocationRootAngle = ARLocationManager.Instance.gameObject.transform.localEulerAngles.y;
        var cameraAngle = Camera.main.transform.localEulerAngles.y;
        var mapAngle = cameraAngle - arLocationRootAngle;

        MapboxMapCamera.transform.eulerAngles = new Vector3(90, mapAngle, 0);

        if ((cameraPos - lastCameraPos).magnitude < MinimapStepSize)
        {
            return;
        }

        lastCameraPos = cameraPos;

        var location = ARLocationManager.Instance.GetLocationForWorldPosition(Camera.main.transform.position);

        Map.SetCenterLatitudeLongitude(new Mapbox.Utils.Vector2d(location.Latitude, location.Longitude));
        Map.UpdateMap();


    }


    void generateRoute(ARLocation.Location _)
    {

        var api = new MapboxApi(MapboxToken);
        var loader = new RouteLoader(api);

        apiError = api.ErrorMessage;

        StartCoroutine(
                    loader.LoadRoute(
                        new RouteWaypoint { Type = RouteWaypointType.UserLocation },
                        new RouteWaypoint { Type = RouteWaypointType.Location, Location = location },
                        (err, res) =>
                        {
                            apiError = err;

                            if (err == null)
                            {

                                RouteContainer.SetActive(true);

                                currentPathRenderer.enabled = true;
                                MapboxRoute.RoutePathRenderer = currentPathRenderer;
                                MapboxRoute.BuildRoute(res);
                                currentResponse = res;
                                buildMinimapRoute(res);

                            }
                            else return;


                        }));

    }

    ARLocation.Location getPlaceLocation(string NombreMonumento)
    {

        ARLocation.Location locationTemp = new ARLocation.Location();


        switch (NombreMonumento)
        {
            case "IndiaCatalina":
                SetLocationLatLong(locationTemp, 10.42648, -75.54404);

                break;

            case "Botas":
                SetLocationLatLong(locationTemp, 10.42127, -75.53764);

                break;

            case "Castillo":
                SetLocationLatLong(locationTemp, 10.42219, -75.53944);

                break;

            case "Torre":
                SetLocationLatLong(locationTemp, 10.423076, -75.549143);

                break;

            case "Pegasos":
                SetLocationLatLong(locationTemp, 10.42216, -75.54878);

                break;

        }

        return location = locationTemp;



    }

    void SetLocationLatLong(ARLocation.Location location, double latitude, double longitude)
    {
        location.Latitude = latitude;
        location.Longitude = longitude;
    }

    public void setMapZoom(string option)
    {
        switch (option)
        {
            case "increase":

                if (mapZoom < 22) mapZoom++;


                break;

            case "decrease":

                if (mapZoom > 10) mapZoom--;
                Map.UpdateMap();

                break;

            default:

                Map.UpdateMap();

                break;
        }

        Map.SetZoom(mapZoom);
        Map.UpdateMap();
    }

    public void makeRoute(string nombreMonumento)
    {
        StartRoute(getPlaceLocation(nombreMonumento));

    }
}

