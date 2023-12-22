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
            print(".a");
            StartCoroutine(Waiter(tiempoEspera));
        }
    }

    IEnumerator Waiter(float seconds)
    {
        print(".b");
        gestoRotar.SetActive(true);
        yield return new WaitForSeconds(seconds);

        print(".c");
        gestoRotar.SetActive(false);
        Destroy(gestoRotar);
        gestoEscalar.SetActive(true);

        yield return new WaitForSeconds(seconds);
        print(".d");
        gestoEscalar.SetActive(false);
        Destroy(gestoEscalar);
        print(".e");
    }

}
