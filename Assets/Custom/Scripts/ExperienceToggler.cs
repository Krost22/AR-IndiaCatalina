using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceToggler : MonoBehaviour
{

    //
    [SerializeField]
    private List<Image> fondosBotones;

    public List<Image> textoBotones;

    public List<Sprite> spriteBotones;

    public GameObject menuInferior;

    GameObject sessionOrigin;

    //Modo Marcadores
    ARTrackedImageManager imageManager;
    TrackedImageSolver imageSolver;

    //Modo Planos
    ARPlaneManager planeManager;
    MeshPlacer meshPlacer;

    GameObject[] estatuas;

    Color selectedText = new Color(255, 255, 255, 255);

    Color idleText = new Color(255, 255, 255, 130);
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

        ModoPlanos();
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

    public void LimpiarPlanos()
    {
            GameObject[] planos = GameObject.FindGameObjectsWithTag("ARPlane");
            foreach (var plano in planos)
            {
                //Destroy(plano);
                plano.SetActive(false);
            }

    }

    public void ModoPlanos()
    {
        imageManager.enabled = false;
        imageSolver.enabled = false;

        planeManager.enabled = true;
        meshPlacer.enabled = true;
        menuInferior.SetActive(true);

        
        fondosBotones[0].sprite = spriteBotones[0];
        fondosBotones[1].sprite = spriteBotones[1];

        textoBotones[0].color = selectedText;
        textoBotones[1].color = idleText;

        LimpiarEstatuas();
    }

    public void ModoMarcadores()
    {
        imageManager.enabled = true;
        imageSolver.enabled = true;

        planeManager.enabled = false;
        meshPlacer.enabled = false;
        menuInferior.SetActive(false);

        fondosBotones[1].sprite = spriteBotones[0];
        fondosBotones[0].sprite = spriteBotones[1];

        textoBotones[1].color = selectedText;
        textoBotones[0].color = idleText;

        LimpiarEstatuas();

        LimpiarPlanos();
    }

}
