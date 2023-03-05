using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplosion : MonoBehaviour
{
    [Header("Asteroid Explosion Settings")]
    [SerializeField] private float explosionForce = 10f;
    [SerializeField] private float explosionRadius = 5f;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip explosionSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = explosionSound;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision?.gameObject.GetComponent<Projectile>())
        {
            _audioSource.PlayOneShot(explosionSound);
            Destroy(gameObject);
        }
    }
}
