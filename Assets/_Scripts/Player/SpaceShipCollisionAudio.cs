using UnityEngine;

public class SpaceShipCollisionAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] spaceShipCollisionSound;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayerCollisions.OnPlayerCollision += HandlePlayerCollisionAudio;
    }

    private void OnDisable()
    {
        PlayerCollisions.OnPlayerCollision -= HandlePlayerCollisionAudio;
    }

    private void HandlePlayerCollisionAudio()
    {
        int randomIndex = UnityEngine.Random.Range(0, spaceShipCollisionSound.Length - 1);
        _audioSource.PlayOneShot(spaceShipCollisionSound[randomIndex]);
    }
}
