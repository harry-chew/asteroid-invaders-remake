using System;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public static event Action OnPlayerCollision;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<IPickUp>() != null)
        {
            IPickUp pickedUpItem = collider.gameObject.GetComponent<IPickUp>();
            pickedUpItem.Collect();
            return;
        }
        GetComponent<PlayerController>().Death();
        OnPlayerCollision?.Invoke();
    }
}
