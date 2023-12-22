using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTutorial : MonoBehaviour
{
    GameObject panelGestos;
    GameObject gestoRotar;
    GameObject gestoEscalar;
    public float tiempoEspera = 5f;

    private void Awake()
    {
        gestoRotar = GameObject.Find("Rotate_Gesto");
        gestoEscalar = GameObject.Find("Scale_Gesto");
        panelGestos = GameObject.Find("PanelGestos");
    }
    void Start()
    {
        panelGestos.SetActive(true);
        gestoRotar.SetActive(true);
        gestoEscalar.SetActive(false);
        

        StartCoroutine(Waiter(tiempoEspera));

    }
    IEnumerator Waiter(float seconds)
    {
        //Inicia contador.
        yield return new WaitForSeconds(seconds);
        //Accion despues del contador.
        gestoRotar.SetActive(false);

        yield return new WaitForSeconds(seconds);
        gestoEscalar.SetActive(false);
        gestoRotar.SetActive(true);
    }

}
