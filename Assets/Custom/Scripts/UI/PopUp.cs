using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class PopUp : MonoBehaviour
{
    public GameManager gameManager;

    public MeshPlacer meshPlacer;

    [SerializeField]
    public TextAsset[] _textosResources;

    [SerializeField]
    public Sprite[] _imagenesResources;

    [SerializeField]
    private GameObject _popUpPrefab;

    public GameObject parentPopUp;

    [SerializeField]
    public List<GameObject> instanciasPopUp = new List<GameObject>();

    public GameObject panelPopUps;
    GameObject[] listaMonumentos;

    void Awake()
    {
        _textosResources = Resources.LoadAll<TextAsset>("Historias");
        _imagenesResources = Resources.LoadAll<Sprite>("ImagenesMon");

        listaMonumentos = meshPlacer.listaMonumentos;
    }
    // Start is called before the first frame update
    void Start()
    {


        //foreach (var monumento in listaMonumentos)
        //{
        //    GameObject popUp = Instantiate(_popUpPrefab, parentPopUp.transform);

        //    popUp.transform.name = monumento.name;

        //    TextMeshProUGUI contenidoTexto = popUp.transform.GetComponentInChildren<TextMeshProUGUI>();

        //    Image imagenMonumento = buscarHijo(popUp, "ImagenMon").GetComponent<Image>();

        //    Button botonCerrar = buscarHijo(popUp, "BotonSalir").GetComponent<Button>();


        //    foreach (var texto in _textosResources)
        //    {
        //        if (texto.name == monumento.name)
        //        {

        //            contenidoTexto.text = texto.text;

        //        }
        //    }

        //    foreach (var imagen in _imagenesResources)
        //    {

        //        if (imagen.name == monumento.name)
        //        {

        //            imagenMonumento.sprite = imagen;

        //        }

        //    }


        //    popUp.SetActive(false);

        //    instanciasPopUp.Add(popUp);

        //}


    }


    public void GeneratePopUps()
    {
        _textosResources = Resources.LoadAll<TextAsset>("Historias");
        _imagenesResources = Resources.LoadAll<Sprite>("ImagenesMon");

        listaMonumentos = meshPlacer.listaMonumentos;

        foreach (var monumento in listaMonumentos)
        {
            GameObject popUp = Instantiate(_popUpPrefab, parentPopUp.transform);

            popUp.transform.name = monumento.name;

            TextMeshProUGUI contenidoTexto = popUp.transform.GetComponentInChildren<TextMeshProUGUI>();

            Image imagenMonumento = buscarHijo(popUp, "ImagenMon").GetComponent<Image>();

            //Button botonCerrar = buscarHijo(popUp, "BotonSalir").GetComponent<Button>();


            foreach (var texto in _textosResources)
            {
                if (texto.name == monumento.name)
                {

                    contenidoTexto.text = texto.text;

                }
            }

            foreach (var imagen in _imagenesResources)
            {

                if (imagen.name == monumento.name)
                {

                    imagenMonumento.sprite = imagen;

                }

            }


            popUp.SetActive(true);

            instanciasPopUp.Add(popUp);

        }
    }

    Transform buscarHijo(GameObject parent, string nombreHijo)
    {

        Transform[] hijos = parent.GetComponentsInChildren<Transform>();

        foreach (var hijo in hijos)
        {
            if (hijo.transform.name == nombreHijo)
            {

                return hijo;
            }

        }

        return null;
    }


}