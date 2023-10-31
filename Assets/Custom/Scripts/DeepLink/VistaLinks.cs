using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaLinks : MonoBehaviour
{
    public GameManager gameManager;
    public const string url = "https://lsvtech.github.io/Treasure-Trail-3DVista/index.htm?media-name=";
    public void abrirLink()
    {
        GameObject monumento = gameManager.obtenerMonumentoActivo();
        switch (monumento.name)
        {
            case "Botas":
                Application.OpenURL(url + "Botas1");
                break;

            case "Castillo":
                Application.OpenURL(url + "Castillo1");
                break;

            case "IndiaCatalina":
                Application.OpenURL(url + "India1");
                break;

            case "Pegasos":
                Application.OpenURL(url + "Pegasos1");
                break;

            case "Torre":
                Application.OpenURL(url + "Torre1");
                break;

            default:
                break;
        }
    } 
}

