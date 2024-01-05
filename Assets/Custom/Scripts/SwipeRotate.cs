using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class SwipeRotate : MonoBehaviour
{

	public Vector3 Axis { set { axis = value; } get { return axis; } } [SerializeField] private Vector3 axis = Vector3.down;

	public Space Space { set { space = value; } get { return space; } } [SerializeField] private Space space = Space.Self;

    public float Sensitivity { set { sensitivity = value; } get { return sensitivity; } } [SerializeField] private float sensitivity = 1.0f;

    LeanFingerSwipe leanFingerSwipe;

    void Start()
    {
        leanFingerSwipe = GetComponent<LeanFingerSwipe>();

        leanFingerSwipe.ScreenDepth.Camera = Camera.main;
    }
    

    public void rotateObject(Vector2 delta){

        var rotate = delta.x * Mathf.Rad2Deg;

			// Perform rotation
		transform.Rotate(axis, rotate, space);
    }
}
