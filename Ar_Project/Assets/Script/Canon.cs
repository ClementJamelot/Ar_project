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
        if(Input.GetKey("q"))
        {
            x=0.5f;
        }
        if(Input.GetKey("d"))
        {
            x=-(0.5f);
        }
        if(Input.GetKey("q") && Input.GetKey("d"))
        {
            x=0;
        }
        
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x,0,z);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
