using UnityEngine;

public class SpaceShipPewPew : MonoBehaviour
{
    [SerializeField] private AudioClip spaceShipPewPewSound;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = spaceShipPewPewSound;
    }
    private void Start()
    {
        PlayerController.OnPlayerShoot += HandlePlayerShootAudio;
    }
    
    private void HandlePlayerShootAudio()
    {
        if(_audioSource != null && spaceShipPewPewSound != null)
            _audioSource.PlayOneShot(spaceShipPewPewSound);
    }
}
