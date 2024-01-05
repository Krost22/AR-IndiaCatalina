using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleClamp : MonoBehaviour
{
    public Vector3 minLocalScale;
    public Vector3 maxLocalScale;
    public float scaleFactor;

    //float minLocalScaleMagnitude;
    //float maxLocalScaleMagnitude;

    // Start is called before the first frame update
    void Awake()
    {
        minLocalScale = transform.localScale;
        // minLocalScaleMagnitude = minLocalScale.magnitude;

        maxLocalScale = minLocalScale * scaleFactor;
        // maxLocalScaleMagnitude = maxLocalScale.magnitude;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float actualLocalScaleMagnitude = transform.localScale.magnitude;

        //_ = Mathf.Clamp(actualLocalScaleMagnitude, minLocalScaleMagnitude, maxLocalScaleMagnitude);

        Vector3 newScale = new Vector3();

        newScale.x = Mathf.Clamp(transform.localScale.x, minLocalScale.x, maxLocalScale.x);
        newScale.y = Mathf.Clamp(transform.localScale.y, minLocalScale.y, maxLocalScale.y);
        newScale.z = Mathf.Clamp(transform.localScale.z, minLocalScale.z, maxLocalScale.z);
        
        transform.localScale = newScale;
    }

    public void OnEnable()
    {
        // Get the direction to the camera (ignoring the Y component)
        Vector3 directionToCamera = Camera.allCameras[0].transform.position - transform.position;
        directionToCamera.y = 0; // Set Y component to 0

        // Rotate the transform to face the camera on the Y-axis only
        transform.rotation = Quaternion.LookRotation(directionToCamera, Vector3.up);
    }

}
