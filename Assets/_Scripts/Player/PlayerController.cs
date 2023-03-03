using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10.0f;

    [Header("Shooting")]
    public bool isFiring;
    public Transform firePoint;
    public GameObject projectile;
    public float fireRate = 0.5f;
    private float fireCooldown;

    [Header("Physics")]
    public Rigidbody rb;

    private Vector3 startPos;  
    void Start()
    {
        startPos = transform.position;
        fireCooldown = 0.0f;
        isFiring = false;
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isFiring = true;
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            isFiring = false;
        }

        if (isFiring)
        {
            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0.0f)
            {
                Fire();
            }
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }

    public void Fire()
    {
        fireCooldown = fireRate;
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision with " + collider.gameObject.name);

        if(collider.gameObject.GetComponent<IPickUp>() != null)
        {
            IPickUp pickedUpItem = collider.gameObject.GetComponent<IPickUp>();
            pickedUpItem.Collect();
            return;
        }
        Death();
    }

    public void Death()
    {
        Lives.Instance.LoseLife();
        transform.position = startPos;
    }
}
