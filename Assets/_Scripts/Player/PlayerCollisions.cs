using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<IPickUp>() != null)
        {
            IPickUp pickedUpItem = collider.gameObject.GetComponent<IPickUp>();
            pickedUpItem.Collect();
            return;
        }
        GetComponent<PlayerController>().Death();
    }
}
