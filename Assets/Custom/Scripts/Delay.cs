using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public GameObject[] cannon;
    public float delay;

    private void Start()
    {
        StartCoroutine("Retrasar");
    }

    IEnumerator Retrasar() 
    {
        yield return new WaitForSeconds(delay);
        foreach (GameObject game in cannon)
        {
            game.GetComponent<Cannon>().enabled = true;
        }
    }
}
