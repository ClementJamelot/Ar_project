using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   [SerializeField] private GameObject lily;

   private float spawnRangeX;
   //private float spawnRangeZ= -1.366f;
   private float startDelay = 2.0f;
   private float spawnInterval = 1.5f;

   [SerializeField] private GameObject spawnpoint;
   [SerializeField] private GameObject spawnpoint_x;
   private float distance;
    // Start is called before the first frame update
    void Start()
    {
        spawnRangeX = spawnpoint.transform.position.x - spawnpoint_x.transform.position.x;
        
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
        
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX)+spawnpoint.transform.position.x,spawnpoint.transform.position.y,spawnpoint.transform.position.z);
        Instantiate(lily,spawnPos,spawnpoint.transform.rotation); 
    }

    public void Stop() {
        CancelInvoke();
    }
}

