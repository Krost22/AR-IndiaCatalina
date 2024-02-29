using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DanielLochner.Assets.SimpleSideMenu;

public class MonumentoUI : MonoBehaviour
{
    public SimpleSideMenu BottomMenu;

    //Prefab del boton
    [SerializeField]
    private GameObject buttonPrefab;

    //El que se encarga de colocar los prefabs, de aqui sacamos dos variables:
    // 1) la lista de monumentos
    // 2) el bool de monumentInScene
    [SerializeField]
    private MeshPlacer meshPlacer;

    //Este es el parent en donde se colocaran los botones generados
    [SerializeField]
    private GameObject parentUI;

    //Este es el target que recibira que Monumento colocar
    [SerializeField]
    private GameObject messageReceiver;

    //Esta es la lista de monumentos colocables
    private GameObject[] listaMonumentosUI;

    //Estos son los sprites de cada Monumento, teniendo en cuenta que el sprite se llame igual que su prefab de monumento
    [SerializeField]
    private List<Sprite> imagesButtons;

    //Este es el encargado de dar la ruta para el RouteMaker
    private RouteMaker routeMaker;

    private void Awake()
    {

        routeMaker = GameObject.FindAnyObjectByType<RouteMaker>();
        //Aqui guardamos los sprites que cargamos
        Object[] resources;

        //Buscamos todos los sprites en la subcarpeta Thumbnails, ubicada en Resources.
        //Esta los regresa como Object.
        resources = Resources.LoadAll("Thumbnails", typeof(Sprite));

        foreach (var item in resources)
        {
            //Con esto pasamos de Object a Sprite 
            imagesButtons.Add(item as Sprite);
        }

        //Aca instanciamos todos los monumentos colocables del meshPlacer
        listaMonumentosUI = meshPlacer.listaMonumentos;



    }
    private void Start()
    {

        //Aqui Recorremos todos los monumentos para crear un boton para cada uno
        foreach (var monumento in listaMonumentosUI)
        {
            //Aqui recuperamos las variables y componentes del boton
            GameObject button = Instantiate(buttonPrefab, parentUI.transform);

            Button buttonComponent = button.GetComponentInChildren<Button>();

            RectTransform buttonRect = button.GetComponent<RectTransform>();
          
            Image imagenMonumento = button.transform.Find("Boton").GetComponent<Image>();

            //Aca setteamos el texto que lleva el boton, en este caso el nombre del monumento.
            //Ojo, esto esta predispuesto a cambios
            TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();

            text.text = monumento.name;

            //Aca recorremos cada sprite en la lista y si este tiene el mismo nombre del monumento, se coloca su respectivo sprite
            foreach (var imageButton in imagesButtons)
            {                     

                if (imageButton.name == monumento.name)
                {
                    
                    imagenMonumento.sprite = imageButton;
                }
            }

            

            //A�adimos los eventos en cada boton
            buttonComponent.onClick.AddListener(delegate { SendPrefab(monumento, messageReceiver); });
            buttonComponent.onClick.AddListener(delegate { LimpiarEstatuas(); });
            buttonComponent.onClick.AddListener(delegate { BottomMenu.ToggleState(); });
            buttonComponent.onClick.AddListener(delegate { routeMaker.makeRoute(monumento.name);    
                print(routeMaker.location);
            });


        }
    }

    //Este envia el mensaje al target, que es el AR Session Origin
    public void SendPrefab(GameObject prefab, GameObject target)
    {
        target.SendMessage("ReceivePrefab", prefab);
    }

    //Con este limpiamos cada que seleccionamos un nuevo monumento, usando el bool MonumentInScene del MeshPlacer
    void LimpiarEstatuas()
    {

        GameObject[] estatuas = GameObject.FindGameObjectsWithTag("Estatua");
        if (meshPlacer.MonumentInScene == true)
        {
            foreach (var objeto in estatuas)
            {
                Destroy(objeto);
            }
            meshPlacer.MonumentInScene = false;
        }

    }


}
