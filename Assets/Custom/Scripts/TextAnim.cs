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
    [SerializeField] GameObject hoja;

    int i = 0;
    int actual = 0;
    int max = 0;

    void Start()
    {
        EndCheck();
    }

    void EndCheck() 
    {
        if (i <= stringArray.Length - 1) 
        {
            _textMeshPro.text = stringArray[i];
            StartCoroutine(TextVisible());
        }
    }

    private IEnumerator TextVisible() 
    {
        _textMeshPro.ForceMeshUpdate();
        int totalVisibleCharacters = _textMeshPro.textInfo.characterCount;
        int counter = 0;

        max = totalVisibleCharacters;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            
            actual = visibleCount;

            _textMeshPro.maxVisibleCharacters = visibleCount;

            if (actual >= max)
            {
                hoja.SetActive(true);
            }

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
