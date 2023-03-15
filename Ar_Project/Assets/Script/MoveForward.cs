using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 1.0f;


    //Fait bouger les enemie
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
