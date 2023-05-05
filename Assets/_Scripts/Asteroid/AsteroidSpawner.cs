using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour, IObserver
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float spawnRadius = 5f;

    [Header("Asteroid Settings")]
    [SerializeField] private float minSize = 0.75f;
    [SerializeField] private float maxSize = 1.55f;

    private void Start()
    {
        GameManager.Instance.RegisterObserver(this);
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveObserver(this);
    }

    public void Notify()
    {
        StartCoroutine(SpawnAsteroid());
    }
    
    private IEnumerator SpawnAsteroid()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0;
        GameObject spawnedAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        InitialiseSpawnedAsteroid(spawnedAsteroid);
        spawnRate *= 0.99f;
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnAsteroid());
    }
    
    private void InitialiseSpawnedAsteroid(GameObject spawnedObject)
    {
        float randomSize = Random.Range(minSize, maxSize);
        Vector3 sizeScale = Vector3.one * randomSize;
        spawnedObject.transform.localScale = sizeScale;
        Rigidbody rigidbody = spawnedObject.GetComponent<Rigidbody>();
        rigidbody.mass = randomSize;
        rigidbody.drag = randomSize;
    }
}
