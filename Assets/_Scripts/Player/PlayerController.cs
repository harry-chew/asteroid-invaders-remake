using UnityEngine;
using System;

public class PlayerController : MonoBehaviour, IObserver
{
    public static event Action OnPlayerShoot;
    


    [Header("Movement")]
    public float speed = 10.0f;

    [Header("Shooting")]
    public Transform firePoint;
    public GameObject projectile;
    public float fireRate = 0.5f;
    private float fireCooldown;

    [Header("Physics")]
    public Rigidbody rb;

    private Vector3 startPos;


    private bool canControl;
    void Start()
    {
        InitPlayer();
    }


    void Update()
    {
        HandlePlayerFire();
    }

    private void InitPlayer()
    {
        canControl = false;
        startPos = transform.position;
        fireCooldown = 0.0f;
        rb = GetComponent<Rigidbody>();
        GameManager.Instance.RegisterObserver(this);
    }
    
    private void HandlePlayerFire()
    {
        if (!canControl) return;
        if (GameInput.Instance.GetFireInput())
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
        HandlePlayerMove();
    }

    private void HandlePlayerMove()
    {
        if (!canControl) return;
        
        float horizontalInput = GameInput.Instance.GetHorizontalInput();
        rb.AddForce(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }

    public void Fire()
    {
        fireCooldown = fireRate;
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        OnPlayerShoot?.Invoke();
    }

    public void Death()
    {
        Lives.Instance.LoseLife();
        transform.position = startPos;
    }

    public void Notify()
    {
        canControl = true;
    }
}
