using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Animator _animPauseMenu;
    [SerializeField] private AudioSource _loseSource;
    [SerializeField] private AudioClip _loseSound;
    [SerializeField] private AudioSource _playSource;
    [SerializeField] private AudioClip _playSound;
    [SerializeField] private AudioSource _exitSource;
    [SerializeField] private AudioClip _exitSound;
    [SerializeField] private AudioSource _restartSource;
    [SerializeField] private AudioClip _restartSound;
    [SerializeField] private AudioSource _resumeSource;
    [SerializeField] private AudioClip _resumeSound;
    [SerializeField] private AudioSource _startSource;
    [SerializeField] private AudioClip _startSound;
    private void Start()
    {
        _loseSource = GetComponent<AudioSource>();
        _playSource = GetComponent<AudioSource>();
        _exitSource = GetComponent<AudioSource>();
        _restartSource = GetComponent<AudioSource>();
        _resumeSource = GetComponent<AudioSource>();
        _startSource = GetComponent<AudioSource>();
    }

    public void StartButto()
    {
        _startSource.PlayOneShot(_startSound, 1f);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
        _exitSource.PlayOneShot(_exitSound, 1f);
        SceneManager.LoadScene("StartMenu");
    }

    public void RestartButton()
    {
        _restartSource.PlayOneShot(_restartSound, 1f);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        _resumeSource.PlayOneShot(_resumeSound, 1f);
        if (Time.timeScale == 1)
        {
            _animPauseMenu.SetTrigger("NotPause");
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        _loseSource.PlayOneShot(_loseSound, 1f);
        if (Time.timeScale == 0)
        {
            _animPauseMenu.SetTrigger("Pause");
        }
    }
}
