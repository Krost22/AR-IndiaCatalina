using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTutorial : MonoBehaviour
{
    //GameObject panelGestos;
    public GameManager gameManager;

    GameObject gestoRotar;
    GameObject gestoEscalar;
    public float tiempoEspera = 5f;

    private void Awake()
    {
        gestoRotar = GameObject.Find("Rotate_Gesto");
        gestoEscalar = GameObject.Find("Scale_Gesto");
       // panelGestos = GameObject.Find("PanelGestos");
    }
    void Start()
    {
        gestoRotar.SetActive(false);
        gestoEscalar.SetActive(false);

        // StartCoroutine(Waiter(tiempoEspera));
    }

    void Update()
    {
        if (gameManager.hayMonumentoActivo==true)
        {
            StartCoroutine(Waiter(tiempoEspera));
        }
    }

    IEnumerator Waiter(float seconds)
    {
        gestoRotar.SetActive(true);
        yield return new WaitForSeconds(seconds);

        gestoRotar.SetActive(false);
        Destroy(gestoRotar);
        gestoEscalar.SetActive(true);

        yield return new WaitForSeconds(seconds);
        gestoEscalar.SetActive(false);
        Destroy(gestoEscalar);
    }

}
