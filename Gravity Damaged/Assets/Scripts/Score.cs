using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    int _score = 0;
    int _highScore = 0;

    [SerializeField] private TextMeshProUGUI _scoreText = default;
    [SerializeField] private TextMeshProUGUI _highScoreText = default;

    public void Awake()
    {
        Instance = this;
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
