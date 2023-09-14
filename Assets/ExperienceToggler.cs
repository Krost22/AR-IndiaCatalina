using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceToggler : MonoBehaviour
{
    public GameObject menuSeleccion;
   

    GameObject sessionOrigin;
    Toggle Toggle;

    //Modo Marcadores
    ARTrackedImageManager imageManager;
    TrackedImageSolver imageSolver;

    //Modo Planos
    ARPlaneManager planeManager;
    MeshPlacer meshPlacer;

    GameObject[] estatuas;
    private void Awake()
    {
        Toggle = this.GetComponent<Toggle>();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        estatuas = GameObject.FindGameObjectsWithTag("Estatua");

        //Modo Marcadores activo
        if (!Toggle.isOn)
        {
            

            imageManager.enabled = true;
            imageSolver.enabled = true;

            planeManager.enabled = false;
            meshPlacer.enabled = false;
            menuSeleccion.SetActive(false);

        }
        //Modo Planos activo
        else if (Toggle.isOn)
        {
           

            imageManager.enabled = false;
            imageSolver.enabled = false;

            planeManager.enabled = true;
            meshPlacer.enabled = true;
            menuSeleccion.SetActive(true);

        }
    }

    public void LimpiarEstatuas()
    {     
        
        foreach (var objeto in estatuas)
        {
            if (objeto.active) Destroy(objeto);
        }

    }

}
