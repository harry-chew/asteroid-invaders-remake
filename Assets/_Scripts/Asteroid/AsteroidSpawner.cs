using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 1f;
    public float spawnRadius = 5f;
    
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
