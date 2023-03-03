using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float x = 0;
        if(transform.position.x<0.25)
        {
            if(Input.GetKey("a"))
            {
                x=(0.5f);
            }  
        }
        
        if(transform.position.x>-0.25)
        {
            if(Input.GetKey("d"))
            {
                x=-(0.5f);
            }
        }
        
        if(Input.GetKey("a") && Input.GetKey("d"))
        {
            x=0;
        }
        
        
        
        Vector3 movement = new Vector3(x,0,0);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
