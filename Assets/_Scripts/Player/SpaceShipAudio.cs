using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipAudio : MonoBehaviour, IObserver
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip engineStartClip;
    [SerializeField] private AudioClip engineLoopClip;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = engineStartClip;
        GameManager.Instance.RegisterObserver(this);
    }
    public void Notify()
    {
        StartCoroutine(StartEngine());
    }
    private IEnumerator StartEngine()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(engineStartClip.length);
        _audioSource.clip = engineLoopClip;
        _audioSource.Play();
        _audioSource.loop = true;
    }

}
