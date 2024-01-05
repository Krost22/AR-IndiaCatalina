using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnim : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textMeshPro;

    public string[] stringArray;

    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;
    [SerializeField] AudioClip[] typingSound;

    [SerializeField] SoundManager soundManager;
    //[SerializeField] GameObject hoja;

    int i = 0;
    int actual = 0;
    int max = 0;

    //void Start()
    //{
    //    //i = 0;
    //    //actual = 0;
    //    //max = 0;
    //    //_textMeshPro.text = "";
    //    EndCheck();
    //}

    //public void ReinicioTexto()
    //{
    //    print(".0");
    //    i = 0;
    //    EndCheck();
    //}

    public void OnEnable()
    {
        print(".0");
        i = 0;
        EndCheck();

        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void EndCheck() 
    {
        print(".a");

        if (i <= stringArray.Length - 1) 
        {
            print(".b");
            _textMeshPro.text = stringArray[i];
            StartCoroutine(TextVisible());
        }
        print(".d");
    }

    private IEnumerator TextVisible() 
    {
        print(".c");
        _textMeshPro.ForceMeshUpdate();
        int totalVisibleCharacters = _textMeshPro.textInfo.characterCount;
        int counter = 0;

        max = totalVisibleCharacters;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            
            actual = visibleCount;

            _textMeshPro.maxVisibleCharacters = visibleCount;

            //if (actual >= max)
            //{
            //    hoja.SetActive(true);
            //}

            if (visibleCount >= totalVisibleCharacters) 
            {
                i += 1;
                Invoke("EndCheck", timeBtwnWords);
                break;
            }

            char currentChar = _textMeshPro.textInfo.characterInfo[visibleCount].character;

            if (!char.IsWhiteSpace(currentChar))
            {
               soundManager.PlaySound(typingSound[Random.Range(0,typingSound.Length-1)]);
            }

            counter += 1;
            //SoundManager.instance.PlaySound(typingSound);
            yield return new WaitForSeconds(timeBtwnChars);
        }
    }

}
