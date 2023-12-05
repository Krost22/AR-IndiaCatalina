using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioAnimator : MonoBehaviour
{
    [SerializeField]
    AudioSource audio;

    [SerializeField]
    Animator[] animators;

    public TimedAnimation timedAnimation;

    int currentTimestampIndex;  

    void Update()
    {
      
        if (audio.isPlaying && currentTimestampIndex < timedAnimation.timestamps.Length)
        {
            float currentTime = audio.time;
            float timestamp = timedAnimation.timestamps[currentTimestampIndex];
            float tolerance = 0.1f;
            
            if (Mathf.Abs(currentTime - timestamp) < tolerance)
            {
                PlayState(currentTimestampIndex);
                currentTimestampIndex++;
            }    
        }
    }

    void PlayState(int index)
    {
        
        if (index < 0 || index >= timedAnimation.stateNames.Length)
        {
            Debug.LogError("Index out of range: " + index);
            return;
        }

       
        string stateName = timedAnimation.stateNames[index];

        foreach (var animator in animators)
        {
            for (int i = 0; i < animator.layerCount; i++)
            {
                animator.Play(stateName,i);
            }
            
        }
        
    }

}
