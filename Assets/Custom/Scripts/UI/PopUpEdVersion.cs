using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpEdVersion : MonoBehaviour
{
    public GameManager gameManager;

    //monumentos
    public GameObject torre;
    public GameObject castillo;
    public GameObject pegasos;
    public GameObject india;
    public GameObject botas;


    // Start is called before the first frame update
    void Awake()
    {
        torre.SetActive(false);
        castillo.SetActive(false);
        pegasos.SetActive(false);
        india.SetActive(false);
        botas.SetActive(false);
    }

    public void OpenAll() 
    {
        torre.SetActive(true);
        castillo.SetActive(true);
        pegasos.SetActive(true);
        india.SetActive(true);
        botas.SetActive(true);
    }
}
