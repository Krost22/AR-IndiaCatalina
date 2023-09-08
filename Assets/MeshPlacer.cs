using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class MeshPlacer : MonoBehaviour
{
    public GameObject[] monumentos = new GameObject[5];
    List<GameObject> monumentosTemp_;
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
       

        if (Physics.Raycast(ray, out hit, 3)) {
            var objetoRng = monumentos[Random.Range(0, monumentos.Length - 1)];

            print(objetoRng.name);

            Instantiate(objetoRng, hit.point, Quaternion.identity);


        }
        

    }
}
