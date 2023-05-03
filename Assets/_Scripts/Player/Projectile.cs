using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Asteroid>())
        {
            //kill asteroid and projectile
            Score.Instance.AddScore(1);
            AudioManager.Instance.PlayAudioClip(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
