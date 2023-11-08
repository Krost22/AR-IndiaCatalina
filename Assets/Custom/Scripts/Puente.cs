using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puente : MonoBehaviour
{
    public Animator animator;
    public GameObject puente;
    public FadeOutObjects fadeObj;

    private void Start()
    {
        if (animator.GetBool("Cerrar") != false) 
        {
            animator.SetBool("Cerrar", false);
        }

        StartCoroutine("PuenteAnim");
    }

    IEnumerator PuenteAnim() 
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Cerrar", true);
        puente.GetComponent<AudioSource>().PlayOneShot(puente.GetComponent<AudioSource>().clip);
        iTween.AudioTo(puente, 0, 1, fadeObj.fadeTime);
    }
}
