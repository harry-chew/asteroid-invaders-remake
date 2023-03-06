using System.Collections;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour, IObserver
{

    [Header("Extra Life")]
    [SerializeField] private GameObject extraLifePickUpPrefab;
    [SerializeField] private float extraLifeSpawnRate = 31f;

    [Header("Extra Score")]
    [SerializeField] private GameObject extraScorePickUpPrefab;
    [SerializeField] private float extraScoreSpawnRate = 11f;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnRadius = 5f;


    private void Start()
    {
        GameManager.Instance.RegisterObserver(this);
    }
    public void Notify()
    {
        StartCoroutine(SpawnExtraScorePickUp());
        StartCoroutine(SpawnExtraLifePickUp());
    }

    private IEnumerator SpawnExtraScorePickUp()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0;
        Instantiate(extraScorePickUpPrefab, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(extraScoreSpawnRate);
        StartCoroutine(SpawnExtraScorePickUp());
    }
    private IEnumerator SpawnExtraLifePickUp()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0;
        Instantiate(extraLifePickUpPrefab, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(extraScoreSpawnRate);
        StartCoroutine(SpawnExtraLifePickUp());
    }
}
