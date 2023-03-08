using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        
        if(other.transform.tag=="plane")
        {
            Destroy(this.transform.gameObject,1);
        }
    }
}

