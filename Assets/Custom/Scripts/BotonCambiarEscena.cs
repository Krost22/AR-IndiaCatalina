using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script debe usarse en un boton canvas con el evento onClick()

public class BotonCambiarEscena : MonoBehaviour
{
    public LevelManager levelManager;

    public void CambiarEscena(string sceneName)
    {
        levelManager.LoadScene(sceneName);
    }
}
