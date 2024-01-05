using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvas;
    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Image _progressBar;


    //-- Para los mensajes de seguridad que iran en el popup --
    [SerializeField] private GameObject _securityCanvas;                // Canvas que contiene las imagenes
    [SerializeField] private Sprite[] _bgContainer;                     // Array de imagenes que contendran los mensajes de seguridad
    [SerializeField] private TMP_Text[] _messages;                      // Contenedor del mensaje

    private float _target;

    public async void LoadScene(string sceneName) 
    {
        _target = 0;                            
        _progressBar.fillAmount = 0;    // Esto es para reiniciar el estado de la barra de carga y que no comience al 100%

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _securityCanvas.SetActive(false);
        _mainMenuCanvas.SetActive(false);
        _loaderCanvas.SetActive(true);

        do
        {
            await Task.Delay(100);
            _target = scene.progress;
        }
        while (scene.progress < 0.9f);  // NO TOCAR NI CAMBIAR PARAMETRO DE 0.9f

        scene.allowSceneActivation = true;
    }

    // Esto eso para hacer aparecer el popup y siempre cambiar el sprite
    public void CanvasSecurity() 
    {
        var ind = 0;
        _securityCanvas.SetActive(true);     //Para que el popup de mensajes de advertencia no salga activo cada que se carga una nueva escena
        _mainMenuCanvas.SetActive(false);
        _loaderCanvas.SetActive(false);

        ind = Random.Range(0, _messages.Length);

        _securityCanvas.GetComponent<Image>().sprite = _bgContainer[Random.Range(0, _bgContainer.Length + 1)];

        for (int i = 0; i < _messages.Length; i++)
        {
            if (i == ind)
                _messages[i].gameObject.SetActive(true);

            else
                _messages[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target, 0.4f * Time.deltaTime);
    }
}
