using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceToggler : MonoBehaviour
{
    //
    [SerializeField]
    private List<Sprite> fondosBotones;

    public List<Image> btnImagenes;

    public GameObject menuInferior;

    GameObject sessionOrigin;

    //Modo Marcadores
    ARTrackedImageManager imageManager;
    TrackedImageSolver imageSolver;

    //Modo Planos
    ARPlaneManager planeManager;
    MeshPlacer meshPlacer;

    GameObject[] estatuas;
    private void Awake()
    {
        
        sessionOrigin = GameObject.Find("AR Session Origin");

        //Modo Marcadores
        imageManager = sessionOrigin.GetComponent<ARTrackedImageManager>();
        imageSolver = sessionOrigin.GetComponent<TrackedImageSolver>();

        //Modo Planos
        planeManager = sessionOrigin.GetComponent<ARPlaneManager>();
        meshPlacer = sessionOrigin.GetComponent<MeshPlacer>();
    }

    private void Start()
    {
        //Activamos el modo planos inicialmente

        imageManager.enabled = false;
        imageSolver.enabled = false;

        planeManager.enabled = true;
        meshPlacer.enabled = true;
        menuInferior.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        estatuas = GameObject.FindGameObjectsWithTag("Estatua");

    }

    public void LimpiarEstatuas()
    {     
        
        foreach (var objeto in estatuas)
        {
            Destroy(objeto);
        }
        meshPlacer.MonumentInScene = false;
    }

    public void ModoPlanos()
    {
        imageManager.enabled = false;
        imageSolver.enabled = false;

        planeManager.enabled = true;
        meshPlacer.enabled = true;
        menuInferior.SetActive(true);

        btnImagenes[0].sprite = fondosBotones[0];
        btnImagenes[1].sprite = fondosBotones[1];

        LimpiarEstatuas();
    }

    public void ModoMarcadores()
    {
        imageManager.enabled = true;
        imageSolver.enabled = true;

        planeManager.enabled = false;
        meshPlacer.enabled = false;
        menuInferior.SetActive(false);

        btnImagenes[0].sprite = fondosBotones[1];
        btnImagenes[1].sprite = fondosBotones[0];

        LimpiarEstatuas();
    }

}
