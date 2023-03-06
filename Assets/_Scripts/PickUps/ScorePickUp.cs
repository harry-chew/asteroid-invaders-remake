using System;
using UnityEngine;

public class ScorePickUp : MonoBehaviour, IPickUp
{
    public event Action OnPickUp;
    [SerializeField] private int scoreToAdd = 5;
    public void Collect()
    {
        Score.Instance.AddScore(scoreToAdd);
        OnPickUp?.Invoke();
        Destroy(gameObject);
    }
}
