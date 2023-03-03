using UnityEngine;

public class ExtraLifePickUp : MonoBehaviour, IPickUp
{
    public void Collect()
    {
        Lives.Instance.AddLife();
        Destroy(gameObject);
    }
}
