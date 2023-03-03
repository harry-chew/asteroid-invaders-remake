using UnityEngine;
using System;

public class Score : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;
    //singleton
    public static Score Instance;
    
    [SerializeField] private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        OnScoreChanged?.Invoke(score);
    }

    public int GetScore()
    {
        return score;
    }
}
