using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private float destroyTime = 4;
   
    
    //Destruction de l'objet si il ne touche pas sa cible au bout d'un certain temps
    private void Update() {
        Destroy(this.gameObject,destroyTime);     
    }

    //Si l'objet touche sa cible il se détruit et détruit l'objet
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag=="lily")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);

            //Appelle la fonction qui rajoute des points au score
            GameObject.Find("Plateform").GetComponent<Canon>().Mise_score();

        }
    }

}

