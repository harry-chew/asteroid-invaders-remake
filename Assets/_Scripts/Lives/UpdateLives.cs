using TMPro;
using UnityEngine;

public class UpdateLives : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    private void OnEnable()
    {
        Lives.OnLivesChanged += HandleOnLiveschange;
    }
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void HandleOnLiveschange(int lives)
    {
        string livesString = lives.ToString();
        textMesh.text = "Lives: " + livesString;
    }
}
