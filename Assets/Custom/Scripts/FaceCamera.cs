using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] Transform camPos;
    [SerializeField] Transform panel;

    private void Start()
    {
        if(camPos == null)
            camPos = GameObject.Find("AR Camera").GetComponent<Transform>();
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(camPos.position.x - panel.position.x, 0 , camPos.position.z - panel.position.z), Vector3.up);
    }
}
