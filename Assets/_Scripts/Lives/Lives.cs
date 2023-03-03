using System;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public static event Action<int> OnLivesChanged;

    //singltone
    public static Lives Instance;
    
    [SerializeField] private int remainingLives = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoseLife()
    {
        remainingLives--;
        CallOnLivesChanged();
        if (remainingLives <= 0)
        {
            Debug.Log("Game Over");
            //Go to hi-score screen
        }
    }

    public void AddLife()
    {
        remainingLives++;
        CallOnLivesChanged();
    }

    public void CallOnLivesChanged()
    {
        OnLivesChanged?.Invoke(remainingLives);
    }
}
