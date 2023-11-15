using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class PopUp : MonoBehaviour
{
    public GameManager gameManager;
   
    public GameObject popUp;

    [SerializeField]
    private TextAsset[] _textosResources;

    [SerializeField]
    private TextMeshProUGUI _textMeshContent;

    [SerializeField]
    private TextMeshProUGUI _textMeshTitle;

    [SerializeField]
    private Image _spriteMon;

    public Sprite[] images;


    private void Awake()
    {
       
        _textosResources = Resources.LoadAll<TextAsset>("Historias");

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void ChangePopUp()
    {
        var monumentoActivo = gameManager.monumentoEscena;
        
        switch (monumentoActivo.name)
        {
            case "IndiaCatalina":

                foreach (var texto in _textosResources)
                {
                    if(texto.name == "IndiaCatalina")
                    {
                        _textMeshContent.text = texto.text;
                        _textMeshTitle.text = "India Catalina";
                        _spriteMon.sprite = images[0];
                    }
                }

                break;

            case "Pegasos":

                foreach (var texto in _textosResources)
                {
                    if (texto.name == "Pegasos")
                    {
                        _textMeshContent.text = texto.text;
                        _textMeshTitle.text = "Muelle de los Pegasos";
                        _spriteMon.sprite = images[1];
                    }
                }

                break;

            case "Botas":

                foreach (var texto in _textosResources)
                {
                    if (texto.name == "Botas")
                    {
                        _textMeshContent.text = texto.text;
                        _textMeshTitle.text = "Los Zapatos Viejos";
                        _spriteMon.sprite = images[2];
                    }
                }

                break;

            case "Castillo":

                foreach (var texto in _textosResources)
                {
                    if (texto.name == "Castillo")
                    {
                        _textMeshContent.text = texto.text;
                        _textMeshTitle.text = "El Castillo San Felipe";
                        _spriteMon.sprite = images[3];
                    }
                }

                break;

            case "Torre":

                foreach (var texto in _textosResources)
                {
                    if (texto.name == "Torre")
                    {
                        _textMeshContent.text = texto.text;
                        _textMeshTitle.text = "La Torre del Reloj";
                        _spriteMon.sprite = images[4];
                    }
                }

                break;

            default:

                _textMeshContent.text = null;
                _textMeshTitle.text = null;
                _spriteMon = null;


                break;
        }
       

    }


}
