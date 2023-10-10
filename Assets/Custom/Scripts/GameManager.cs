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

}