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
    private TextAsset[] _textosResources;

    [SerializeField]
    private Sprite[] _imagenesResources;

    
    public GameObject _popUpPrefab;

    public GameObject parentPopUp;

    public List<GameObject> instanciasPopUp = new List<GameObject>();

    public GameObject[] listaMonumentos;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _textosResources = Resources.LoadAll<TextAsset>("Historias");
        if (_textosResources != null) print("Documentos cargados");
        _imagenesResources = Resources.LoadAll<Sprite>("ImagenesMon");

        listaMonumentos = meshPlacer.listaMonumentos;

        foreach (var monumento in listaMonumentos)
        {
            
            GameObject popUp = Instantiate(_popUpPrefab, parentPopUp.transform);

            popUp.transform.name = monumento.name;

            TextMeshProUGUI contenidoTexto = popUp.transform.GetComponentInChildren<TextMeshProUGUI>();

            Image imagenMonumento = buscarHijo(popUp, "ImagenMon").GetComponent<Image>();

            Button botonCerrar = buscarHijo(popUp, "BotonSalir").GetComponent<Button>();


             foreach (var texto in _textosResources)
             {
                 if(texto.name == monumento.name){

                     contenidoTexto.text = texto.text;

                    print("TEXTO DE ASSET" + texto.text);

                }
             }

             foreach (var imagen in _imagenesResources)
             {

                 if(imagen.name == monumento.name){

                     imagenMonumento.sprite = imagen;

                 }

             }   


            popUp.SetActive(false);

            instanciasPopUp.Add(popUp);
            
        }
        

    }

    public void ChangePopUp()
     {
        

         GameObject monumentoActivo = gameManager.monumentoEscena;

         foreach (var popUp in instanciasPopUp)
         {
            print(popUp.transform.name);

             if (popUp.transform.name == monumentoActivo.name)
             {
                 popUp.SetActive(true);
                print("popUp Cambiado");

            } else popUp.SetActive(false);
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
