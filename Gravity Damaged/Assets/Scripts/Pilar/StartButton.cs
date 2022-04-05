using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartButto()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
