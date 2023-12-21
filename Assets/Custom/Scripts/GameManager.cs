using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int target = 60;
    public GameObject monumentoEscena;

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
    }

    public void obtenerMonumentoActivo()
    {
        GameObject[] listaMonumentos;

        listaMonumentos = GameObject.FindGameObjectsWithTag("Estatua");

        foreach (var monumento in listaMonumentos)
        {
            if(monumento.activeSelf == true)
            {
                monumentoEscena = monumento;
            }
        }
    }
}