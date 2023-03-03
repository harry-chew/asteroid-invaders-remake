using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }       
}
