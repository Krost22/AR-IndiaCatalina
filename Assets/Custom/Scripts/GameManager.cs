using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ExperienceToggler experienceToggler;
    public void ChangeScene(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
        
    }

    public void Limpiar()
    {
        experienceToggler.LimpiarEstatuas();
    }
    
}