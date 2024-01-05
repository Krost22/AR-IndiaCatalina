using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImageSolver : MonoBehaviour
{
    
    public GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager _arManager;
    // Start is called before the first frame update
    private void Awake()
    {
        _arManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            newPrefab.SetActive(false);
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    private void OnEnable()
    {
        _arManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        _arManager.trackedImagesChanged -= ImageChanged;
    }

    public void ImageChanged(ARTrackedImagesChangedEventArgs args) 
    {
        foreach (var trackedImage in args.added)
        {
            UpdateImage(trackedImage);

        }
        foreach (var trackedImage in args.updated)
        {
            UpdateImage(trackedImage);

        }
        foreach (var trackedImage in args.removed)
        {
            spawnedPrefabs[trackedImage.name].SetActive(false);

        }

    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {

        string name = trackedImage.referenceImage.name;
        Transform transform = trackedImage.transform;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = transform.position + new Vector3(0, 0.125f, 0);
        prefab.SetActive(true);

        foreach (GameObject gameObject in spawnedPrefabs.Values)
        {
            if(gameObject.name != name)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
