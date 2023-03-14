using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private float destroyTime = 4;
   
    

    private void Update() {

        Destroy(this.gameObject,destroyTime);
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag=="lily")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);


            GameObject.Find("Plateform").GetComponent<Canon>().Mise_score();

        }
    }

}

