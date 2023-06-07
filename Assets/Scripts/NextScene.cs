using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void NScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
    }
}
