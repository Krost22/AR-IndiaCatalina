using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public enum ModoDeManipulacion { 

rotacion,
escala

}

public class CameraInstancer : MonoBehaviour
{
    ModoDeManipulacion modo;

    LeanPinchScale scale;

    LeanTwistRotateAxis rotate;

    LeanFingerTap tap;

    // Start is called before the first frame update
    private void Awake()
    {
        scale = this.gameObject.GetComponent<LeanPinchScale>();
        rotate = this.gameObject.GetComponent<LeanTwistRotateAxis>();
        tap = this.gameObject.GetComponent<LeanFingerTap>();

        modo = ModoDeManipulacion.rotacion;
    }

    void Start()
    {
        
        rotate.enabled = true;
        scale.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        switch (modo)
        {
            case ModoDeManipulacion.rotacion:
                rotate.enabled = true;
                scale.enabled = false;
                break;
            case ModoDeManipulacion.escala:
                rotate.enabled = false;
                scale.enabled = true;
                break;
            default:
                break;
        }
    }

    public void cambiarModo() {

        this.modo = 
            this.modo == ModoDeManipulacion.rotacion ? ModoDeManipulacion.escala : ModoDeManipulacion.rotacion;


    }
}
