using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum tipoSlider
{
    superior,
    lateral
}

public class MenuSlider : MonoBehaviour
{
    enum estadoBoton
    {
        abierto,
        cerrado
    }

    public tipoSlider tipoSlider;

    estadoBoton estado;

    RectTransform boton;

    [SerializeField]
    RectTransform panelDesignado;

    private void Start()
    {
        estado = estadoBoton.cerrado;
        boton = this.GetComponent<RectTransform>();
    }

    public void Animar()
    {
        switch (estado)
        {
            case estadoBoton.abierto:
                Desplegar();
                break;
            case estadoBoton.cerrado:
                Recoger();
                break;
            default:
                break;
        }
    }
    public void Desplegar()
    {
       

        switch (tipoSlider)
        {
            case tipoSlider.superior:



                break;
            case tipoSlider.lateral:



                break;
            default:
                break;
        }

        estado = estadoBoton.abierto;
    }

    public void Recoger()
    {
        
        
        switch (tipoSlider)
        {
            case tipoSlider.superior:



                break;

            case tipoSlider.lateral:



                break;
            default:
                break;
        }

        estado = estadoBoton.cerrado;
    }

}
