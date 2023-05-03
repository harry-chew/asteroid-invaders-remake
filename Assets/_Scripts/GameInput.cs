using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool GetFireInput()
    {
        return Input.GetButton("Fire1");
    }
}
