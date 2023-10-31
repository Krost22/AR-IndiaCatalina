using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int target = 60;
    void Awake()
    {
        QualitySettings.vSyncCount = 1;
    }

    
    public void ChangeScene(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
        
    }

    public GameObject obtenerMonumentoActivo()
    {
        GameObject[] listaMonumentos;

        listaMonumentos = GameObject.FindGameObjectsWithTag("Estatua");

        GameObject monumentoActivo;

        foreach (var monumento in listaMonumentos)
        {
            if(monumento.activeSelf == true)
            {
                monumentoActivo = monumento;

            }
        }

        if (monumentoActivo = null)
        {
            return null;
        }
        else return monumentoActivo;
    }

}