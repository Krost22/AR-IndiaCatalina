using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VistaLinks : MonoBehaviour
{
    public GameManager gameManager;
    public string url;

    public void abrirLink()
    {
        GameObject monumento = gameManager.monumentoEscena;
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

