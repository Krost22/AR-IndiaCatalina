using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TimedAnimation : ScriptableObject
{
    public string[] stateNames;

    public float[] timestamps;
}
