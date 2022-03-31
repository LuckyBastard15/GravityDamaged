using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField]private Text _scoreText;
    [SerializeField]private Text _highScoreText;
    int _score = 0;
    int _highScore = 0;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("Highscore", 0);
        _scoreText.text = _score.ToString();
        _highScoreText.text = _highScore.ToString();
    }

    public void AddPoint()
    {
        _score += 1;
        _scoreText.text = _score.ToString();
        if (_highScore <= _score)
        {
            PlayerPrefs.SetInt("Highscore", _score);
        }
    }
}
