using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("Switch by Scene Name")]
    [SerializeField] private string sceneName;

    [Header("Quit Button")]
    [SerializeField] private bool quitButton;
    public void SwitchSceneByString()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        if (quitButton)
        {
            Application.Quit();
        }
    }
}
