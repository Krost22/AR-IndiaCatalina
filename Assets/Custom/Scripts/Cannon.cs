using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public AudioSource[] cannonSounds;
    public ParticleSystem[] smokeParticles;

    void playCannons()
    {

        foreach (AudioSource cannonSound in cannonSounds)
        {
            cannonSound.Play();

        }
        foreach (ParticleSystem smokeParticle in smokeParticles)
        {
            smokeParticle.Play();
        }
    }
    
}
