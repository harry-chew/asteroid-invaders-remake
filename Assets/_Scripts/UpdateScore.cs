using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    private void OnEnable()
    {
        Score.OnScoreChanged += HandleOnScoreChange;
    }
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void HandleOnScoreChange(int score)
    {
        textMesh.text = "Score: {score}";
    }
}
