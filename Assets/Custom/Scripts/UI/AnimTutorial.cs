using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimTutorial : MonoBehaviour
{
    public GameObject panelTutorial;
    public GameManager gameManager;

    public GameObject[] arrayGestos = new GameObject[3];
    GameObject gestoRotar;
    GameObject gestoEscalar;

    public Button botonDerecho;
    public Button botonIzquierdo;
    public int posicionActual;

    //public float tiempoEspera = 5f;
    private void Awake()
    {
        posicionActual = 0;

        foreach (GameObject gesto in arrayGestos)
        {
            if (gesto != arrayGestos[posicionActual])
            {
                gesto.SetActive(false);
            }
        }
    }
    void Start()
    {
        botonDerecho.onClick.AddListener(delegate { 

            SubirIndice();
            ActualizarInfo();

        });

        botonIzquierdo.onClick.AddListener(delegate { 

            BajarIndice();
            ActualizarInfo();

        });

        
        // StartCoroutine(Waiter(tiempoEspera));
    }

    void Update()
    {   

        
        //if (gameManager.hayMonumentoActivo==true)
        //{
        //    StartCoroutine(Waiter(tiempoEspera));
        //}


    }

    //IEnumerator Waiter(float seconds)
    //{
    //    gestoRotar.SetActive(true);
    //    yield return new WaitForSeconds(seconds);

    //    gestoRotar.SetActive(false);
    //    Destroy(gestoRotar);
    //    gestoEscalar.SetActive(true);

    //    yield return new WaitForSeconds(seconds);
    //    gestoEscalar.SetActive(false);
    //    Destroy(gestoEscalar);
    //}

    public void SubirIndice()
    {
        if (posicionActual >= 0 && posicionActual <=2)
        {
            posicionActual += 1;
        }
    }

    public void BajarIndice()
    {
        if (posicionActual >= 0 && posicionActual <= 2)
        {
            posicionActual -= 1;
        }
    }

    public void ReiniciarIndice()
    {
        posicionActual = 0;
    }

    public void ActualizarInfo()
    {
        foreach (GameObject gesto in arrayGestos)
        {
            if (gesto != arrayGestos[posicionActual])
            {
                gesto.SetActive(false);
            }
            else gesto.SetActive(true);
        }


        switch (posicionActual)
        {
            case 0:
                //TODO: Activar solamente el boton derecho y desactivar izquierdo;
                botonDerecho.gameObject.SetActive(true);
                botonIzquierdo.gameObject.SetActive(false);
                break;

            case 1:
                //TODO: Activar ambos botones
                botonDerecho.gameObject.SetActive(true);
                botonIzquierdo.gameObject.SetActive(true);
                break;

            case 2:
                //TODO: Activar solamente el boton izquierdo y desactivar derecho;
                botonDerecho.gameObject.SetActive(false);
                botonIzquierdo.gameObject.SetActive(true);
                break;

            default:
                break;
        }
    }

}
