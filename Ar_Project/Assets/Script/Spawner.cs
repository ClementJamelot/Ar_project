using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject lily;

   private float spawnRangeX= 0.25f;
   private float spawnRangeZ= -1.366f;
   private float startDelay = 2.0f;
   private float spawnInterval = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    void SpawnRandomAnimal()
    {
      
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,spawnRangeZ);
        Instantiate(lily,spawnPos,lily.transform.rotation);

    }

    public void Stop() {
        CancelInvoke();
    }
}

