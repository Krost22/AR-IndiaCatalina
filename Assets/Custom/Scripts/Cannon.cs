using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public AudioSource cannon;
    public ParticleSystem smoke;
    bool shoot = false;

    void Update()
    {
        if (shoot == false)
        {
            StartCoroutine("Randomizer");
        }
    }

    IEnumerator Randomizer() 
    {
        shoot = true;
        cannon.PlayOneShot(cannon.clip);
        smoke.Play();
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        shoot = false;
    }
}
