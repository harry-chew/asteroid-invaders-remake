using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour, IObserver
{
    [SerializeField] private float speed = 0.5f;
    private Renderer renderer;

    [SerializeField] private bool canScroll;

    public void Notify()
    {
        canScroll = true;
    }

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        canScroll = false;
    }

    private void Start()
    {
        GameManager.Instance.RegisterObserver(this);
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveObserver(this);
    }
    void Update()
    {
        if(canScroll)
        {
            Vector2 offset = new Vector2(0, Time.time * speed);
            renderer.material.mainTextureOffset = offset;
        }
    }
}
