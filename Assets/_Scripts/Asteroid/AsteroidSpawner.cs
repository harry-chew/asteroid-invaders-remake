using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float spawnRadius = 5f;
    
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
