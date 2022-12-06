using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System; 

public class HeadController : MonoBehaviour
{
    [SerializeField]
    GameObject toBeControlled; 


/*
    float velocity = 50; 
    float run = 1; 

    void Update()
    {
        var lAngles = this.transform.rotation.eulerAngles;
        var tbcAngles = toBeControlled.transform.rotation.eulerAngles;

        while( (lAngles.z > 50) ) 
        {
            if(true)
            {            
                toBeControlled.transform.Rotate(  Vector3.up * velocity * Time.deltaTime, Space.World ); 
            }

            print( tbcAngles  );
        }
    }
*/


    bool start = false; 
    float velocity = 50; 

    void Update()
    {
        var lAngles = this.transform.rotation.eulerAngles;
        var tbcAngles = toBeControlled.transform.rotation.eulerAngles;


        start = false; 
        if( (lAngles.z > 50) ) start = true; 

        //if( (tbcAngles.y < 180)  && start) 
        if( start ) 
        {
            //if( tbcAngles.y < 90 )
            toBeControlled.transform.Rotate(  Vector3.up * velocity * Time.deltaTime, Space.World ); 
            print( "tbcAngles" + tbcAngles );   
        }


    }





}
