using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]private Animator _animPauseMenu;
    
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
            _animPauseMenu.SetTrigger("NotPause");
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        if (Time.timeScale == 0)
        {
            _animPauseMenu.SetTrigger("Pause");
        }
    }
}
