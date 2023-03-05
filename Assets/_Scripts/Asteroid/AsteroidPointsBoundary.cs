using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPointsBoundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>())
        {
            Destroy(collision.gameObject);
        }   
    }
}
