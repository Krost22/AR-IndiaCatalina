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

    public GameObject[] listaMonumentos = new GameObject[5];


    //Se hace una instancia del monumento a spawnear
    [Tooltip("Este es el monumento enviado por la UI para spawnear")]
    [SerializeField]
    GameObject monumentoElegido;

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

        Instantiate(monumentoElegido, hit.point, Quaternion.identity);

        MonumentInScene = true;
        meshPlacer.enabled = false;

    }

    public GameObject ReceivePrefab(GameObject prefab)
    {
        monumentoElegido = prefab;
        return prefab;
    }
}
