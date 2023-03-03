using UnityEngine;

public class DisplayHiScore : MonoBehaviour
{
    void Start()
    {
        if (Score.Instance != null)
        {
            GetComponent<TMPro.TextMeshProUGUI>().text = Score.Instance.GetScore().ToString();
        }
    }
}
