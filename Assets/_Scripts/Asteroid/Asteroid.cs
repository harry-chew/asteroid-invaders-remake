using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Asteroid Rotation Settings")]
    [SerializeField] private float multiplier = 1f;
    [SerializeField] private float minForce = 1f;
    [SerializeField] private float maxForce = 5f;

    private Rigidbody _rigidbody;
    private void Start()
    {
        InitialiseAsteroid();
    }

    private void InitialiseAsteroid()
    {
        float randomForce = GetRandomForce(minForce, maxForce);
        Vector3 randomDirection = GetRandomStartingTorqueVector3();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddTorque(randomDirection * randomForce * multiplier);
    }

    public float GetRandomForce(float minForce, float maxForce)
    {
        return Random.Range(minForce, maxForce);
    }

    public Vector3 GetRandomStartingTorqueVector3()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}
