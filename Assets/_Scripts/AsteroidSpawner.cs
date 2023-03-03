using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 1f;
    public float spawnRadius = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad % spawnRate < Time.deltaTime)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPosition.z = 0;
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            spawnRate *= 0.99f;
        }
    }
}
