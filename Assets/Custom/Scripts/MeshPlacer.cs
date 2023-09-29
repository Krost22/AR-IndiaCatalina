using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.UI;
using TMPro;

public class MeshPlacer : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer;

    [SerializeField]
    private TMP_Dropdown dropdown;

    //se referencia al mismo script para que este sea capaz de desactivarse solo
    private MeshPlacer meshPlacer;

    [Tooltip("Esta es la lista de monumentos que apareceran al tocar el plano detectado")]
    public GameObject[] listaMonumentos = new GameObject[5];
    // List<GameObject> monumentosTemp_;
    public bool MonumentInScene;
    Camera camera;
  
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {

            

                placePrefab(Input.GetTouch(0).position);
            
            
        
        }
    }

    public void placePrefab(Vector3 pos) {
       
        Ray ray = camera.ScreenPointToRay(pos);
        
        RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit, Mathf.Infinity , layer)&& MonumentInScene == false) {

            InstantiateMesh(hit);

        }
        

    }

    public void InstantiateMesh(RaycastHit hit)
    {
        var objetoRng = listaMonumentos[dropdown.value];

        Instantiate(objetoRng, hit.point, Quaternion.identity);

        MonumentInScene = true;
        meshPlacer.enabled = false;

    }
}