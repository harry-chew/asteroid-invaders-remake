using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, ISubject
{
    public static GameManager Instance;
    [SerializeField] private List<IObserver> observers = new List<IObserver>();

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Notify();
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

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
    
    public IEnumerator GameStart()
    {
        yield return new WaitForSeconds(3f);
        Score.Instance.ResetScore();
        NotifyObservers();
    }
}
