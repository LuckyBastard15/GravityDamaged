using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu = null;
    
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

    public void ResumeButton()
    {
        Time.timeScale = 1;
        if (Time.timeScale == 1)
        {
            _pauseMenu.SetActive(false);
            
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        if (Time.timeScale == 0)
        {
            _pauseMenu.SetActive(true);
        }
    }
}
