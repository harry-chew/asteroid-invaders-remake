using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour, IObserver
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float spawnRadius = 5f;

    private void Start()
    {
        GameManager.Instance.RegisterObserver(this);
    }
    public void Notify()
    {
        StartCoroutine(SpawnAsteroid());
    }
    
    private IEnumerator SpawnAsteroid()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0;
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        spawnRate *= 0.99f;
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnAsteroid());
    }

}
