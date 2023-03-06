using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipParticle : MonoBehaviour, IObserver
{
    [SerializeField] private ParticleSystem spaceShipParticle;
    public void Notify()
    {
        spaceShipParticle.Play();
    }
    
    void Awake()
    {
        spaceShipParticle = GetComponent<ParticleSystem>();
        spaceShipParticle.Stop();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.RegisterObserver(this);
    }
}
