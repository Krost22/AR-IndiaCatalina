using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int target = 60;
    public GameObject monumentoEscena;

    public bool hayMonumentoActivo
    {
        get;
        private set;
    }

    void Awake()
    {
        QualitySettings.vSyncCount = 1;
    }

    
    public void ChangeScene(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
        
    }

    private void Update()
    {
        obtenerMonumentoActivo();

        //comentado por ahora hasta verificar si es necesario
       // if (monumentoEscena) ChangePopUp();
    }

    public void obtenerMonumentoActivo()
    {
        GameObject[] listaMonumentos;

        listaMonumentos = GameObject.FindGameObjectsWithTag("Estatua");

        foreach (var monumento in listaMonumentos)
        {
            if (monumento.activeSelf == true)
            {
                monumentoEscena = monumento;

                hayMonumentoActivo = true;
            }
            else hayMonumentoActivo = false;
        }
    }

    public void ChangePopUp()
    {
        GameObject[] popUps = new GameObject[5];
        popUps = GameObject.FindGameObjectsWithTag("PopUp");

        foreach (var popUp in popUps)
        {
            if (popUp.transform.name == monumentoEscena.name)
            {
                popUp.SetActive(true);

            }
            else popUp.SetActive(false);
        }

    }

}