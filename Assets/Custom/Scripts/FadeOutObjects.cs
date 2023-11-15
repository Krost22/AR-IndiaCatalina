using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutObjects : MonoBehaviour
{
    public GameObject[] objectsToFade;
    public GameObject[] audiosToFade;

    public TimedAnimation timedAnimation;

    //public float waitTime;
    public float fadeTime;

    private void Start()
    {
        StartCoroutine("fadeOut");
    }

    private void Update()
    {

    }

    IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(timedAnimation.timestamps[0]);
        SetMaterialTransparent();

        foreach (GameObject gObject in objectsToFade)
        {
            if (gObject.name != "Base.002")
                iTween.FadeTo(gObject, 0, fadeTime);
            else
                iTween.FadeTo(gObject, 1, fadeTime);
        }

        yield return new WaitForSeconds(fadeTime);

        foreach (GameObject g in objectsToFade)
        {
            if (g.name != "Base.002")
                g.SetActive(false);
            else if (g.GetComponent<Terrain>() != null)
            {
                g.SetActive(false);
            }
        }
    }

    void SetMaterialTransparent()
    {
        foreach (GameObject g in objectsToFade)
        {
            if (g.GetComponent<Terrain>() == null)
            {
                foreach (Material m in g.GetComponent<Renderer>().materials)
                {
                    m.SetFloat("_Mode", 2);
                    m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    m.SetInt("_ZWrite", 0);
                    m.DisableKeyword("_ALPHATEST_ON");
                    m.EnableKeyword("_ALPHABLEND_ON");
                    m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    m.renderQueue = 3000;
                }
            }
        }

        foreach (GameObject audio in audiosToFade)
        {
            iTween.AudioTo(audio, 0, 1, fadeTime);
        }
    }
}
