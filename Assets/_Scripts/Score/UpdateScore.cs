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
        string scoreString = score.ToString();
        textMesh.text = "Score: " + scoreString;
    }
}
