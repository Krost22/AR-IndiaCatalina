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
    private TextAsset[] textos;

    [SerializeField]
    private TextMeshProUGUI _textMesh;

    public Sprite[] images;

    private void Awake()
    {
       
        textos = Resources.LoadAll<TextAsset>("Historias");

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

                foreach (var texto in textos)
                {
                    if(texto.name == "IndiaCatalina")
                    {
                        _textMesh.text = texto.text;
                    }
                }

                break;

            case "Pegasos":

                foreach (var texto in textos)
                {
                    if (texto.name == "Pegasos")
                    {
                        _textMesh.text = texto.text;
                    }
                }

                break;

            case "Botas":

                foreach (var texto in textos)
                {
                    if (texto.name == "Botas")
                    {
                        _textMesh.text = texto.text;
                    }
                }

                break;

            case "Castillo":

                foreach (var texto in textos)
                {
                    if (texto.name == "Castillo")
                    {
                        _textMesh.text = texto.text;
                    }
                }

                break;

            case "Torre":

                foreach (var texto in textos)
                {
                    if (texto.name == "Torre")
                    {
                        _textMesh.text = texto.text;
                    }
                }

                break;

            default:

                _textMesh.text = null;

                break;
        }
    }
}
