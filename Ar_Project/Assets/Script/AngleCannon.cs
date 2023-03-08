using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleCannon : MonoBehaviour
{
    public float speed = 0.2f;


    void Update()
    {

        Quaternion startRotation = transform.rotation;
         float x = 0;
        if(transform.rotation.x<0)
        {
            if(Input.GetKey("w"))
            {
                x=(10);
            }  
        }
        
        if(transform.position.x>-55)
        {
            if(Input.GetKey("s"))
            {
                x=-(10);
            }
        }
        
        if(Input.GetKey("w") && Input.GetKey("s"))
        {
            x=0;
        }
       
        Quaternion target = startRotation* Quaternion.Euler(x, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * speed);
        



    }
}
