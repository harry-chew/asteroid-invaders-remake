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

    // Start is called before the first frame update
    void Start()
    {
        spaceShipParticle = GetComponent<ParticleSystem>();
        spaceShipParticle.Stop();
        GameManager.Instance.RegisterObserver(this);
    }
}
