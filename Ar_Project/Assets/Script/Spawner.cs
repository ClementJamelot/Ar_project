using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   [SerializeField] private GameObject lily;

   private float spawnRangeX= 0.25f;
   //private float spawnRangeZ= -1.366f;
   private float startDelay = 2.0f;
   private float spawnInterval = 2.5f;

   [SerializeField] private GameObject spawnpoint;
   [SerializeField] private GameObject spawnpoint_x;
    // Start is called before the first frame update
    void Start()
    {
        spawnRangeX = spawnpoint_x.transform.position.x;
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
        
    }

    void SpawnRandomAnimal()
    {
        Vector3 The_position = spawnpoint.transform.TransformPoint(spawnpoint.transform.position);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX)+The_position.x,The_position.y,The_position.z);
        Instantiate(lily,spawnPos,spawnpoint.transform.rotation);

    }

    public void Stop() {
        CancelInvoke();
    }
}

