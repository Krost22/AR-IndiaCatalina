using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class GestureManager : MonoBehaviour
{
    public LeanFingerFilter Use = new LeanFingerFilter(true);
    public Vector3 Axis { set { axis = value; } get { return axis; } } [SerializeField] private Vector3 axis = Vector3.down;
	public Space Space { set { space = value; } get { return space; } } [SerializeField] private Space space = Space.Self;
	public float Sensitivity { set { sensitivity = value; } get { return sensitivity; } } [SerializeField] private float sensitivity = 1.0f;

    public LeanPinchScale leanPinchScale;
    GameObject target;
    public GameManager gameManager;

    Vector2 swipeDelta;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
        leanPinchScale = this.GetComponent<LeanPinchScale>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.monumentoEscena != null)
        {
            target = gameManager.monumentoEscena;

            leanPinchScale.Use.RequiredSelectable = target.GetComponent<LeanSelectableByFinger>();

            int fingersActive = Use.UpdateAndGetFingers(true).Count;

            print(fingersActive);

            if(fingersActive == 1)
            {
                leanPinchScale.enabled = false;
                var finger = Use.UpdateAndGetFingers()[0];

                if (finger != null)
                {

                    if (!finger.IsActive)
                    {

                        swipeDelta = Vector2.zero;

                    }
                    else
                    {

                        swipeDelta = finger.SwipeScreenDelta;

                        RotarMonumento(swipeDelta);
                    }


                }

            }
            else if(fingersActive > 1)
            {
                leanPinchScale.enabled = true;
            }

            
        }
       
    }

   

    public void RotarMonumento(Vector2 amount){

        target.transform.Rotate(axis, amount.x * 0.01f, space);
    }
}
