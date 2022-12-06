using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour
{

[SerializeField]
GameObject left; 
 
[SerializeField]
GameObject right; 


    bool start = false; 

    float move = 0;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
    }


    void OnTriggerEnter(Collider other) 
    {
        print( "OnTriggerEnter: -" + other.name + "-  ");

        if( other.name.Contains("XR Origin") ) start = true; 
        
        if(start) move = 0;
    }


    // Update is called once per frame
    void Update()
    {

if(start)
{

    left.transform.Translate(Vector3.forward * Time.deltaTime * 0.5f, Space.World);
    right.transform.Translate(Vector3.back * Time.deltaTime * 0.5f, Space.World);
}

    }
}
