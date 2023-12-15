using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject _mainMenuCanvas;
    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Image _progressBar;

    //-- Para los mensajes de seguridad que iran en el popup --
    // [SerializeField] private GameObject _securityPopup;         // Canvas que contiene las imagenes
    // [SerializeField] private Image _messageContainer;           // Contenedor del mensaje
    // [SerializeField] private Sprite[] _messages;                // Array de imagenes que contendran los mensajes de seguridad

    private float _target;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(_mainMenuCanvas.gameObject);
        DontDestroyOnLoad(_loaderCanvas.gameObject);
        DontDestroyOnLoad(_progressBar.gameObject);
    }

    public async void LoadScene(string sceneName) 
    {
        _target = 0;                            
        _progressBar.fillAmount = 0;    // Esto es para reiniciar el estado de la barra de carga y que no comience al 100%

        // _securityPopup.SetActive(false);     //Para que el popup de mensajes de advertencia no salga activo cada que se carga una nueva escena

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _mainMenuCanvas.SetActive(false);
        _loaderCanvas.SetActive(true);

        do
        {
            await Task.Delay(100);
            _target = scene.progress;
        }
        while (scene.progress < 0.9f);  // NO TOCAR NI CAMBIAR PARAMETRO DE 0.9f

        // Esto eso para hacer aparecer el popup y siempre cambiar el sprite
        // _securityPopup.SetActive(true);
        // _messageContainer.sprite = _messages[Random.Range(0,_messages.Length + 1)];      //siempre cambia el mensaje por uno aleatorio cada que se llama la pantalla de carga


        scene.allowSceneActivation = true;
    }

    private void Update()
    {
        _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target, 0.4f * Time.deltaTime);
    }
}
