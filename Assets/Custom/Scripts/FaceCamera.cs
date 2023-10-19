using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] Transform camPos;
    [SerializeField] Transform panel1;
    [SerializeField] Transform panel2;

    private void Start()
    {
        if(camPos == null)
            camPos = GameObject.Find("AR Camera").GetComponent<Transform>();
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(camPos.position.x - panel1.position.x, 0 , camPos.position.z - panel1.position.z), Vector3.up);

        transform.rotation = Quaternion.LookRotation(new Vector3(camPos.position.x - panel2.position.x, 0, camPos.position.z - panel2.position.z), Vector3.up);
    }
}
