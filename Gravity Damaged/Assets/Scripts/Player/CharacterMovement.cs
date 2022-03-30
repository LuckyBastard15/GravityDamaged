using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Pillar[] _pillars = null;
    private int _currentPillar = 0;
    private bool _isRight = true;
    [SerializeField] private Transform _camara = null;
    [SerializeField] private DuplicateBase _duplicateBase = null;
    [SerializeField] private GameObject _pauseMenu = null;

    private void Start()
    {
        _pauseMenu.SetActive(false);
        UpdatePosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveR();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveL();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _duplicateBase.SpawnTriggerEntered();
    }

    public void MoveR()
    {
            if (_isRight)
            {
                _currentPillar++;
                _currentPillar = _currentPillar >= _pillars.Length ? 0 : _currentPillar;
                _isRight = false;
            }
            else
            {
                _isRight = true;
            }
        UpdatePosition();
    }

    public void MoveL()
    {
            if (_isRight)
            {
                _isRight = false;
            }
            else
            {
                _isRight = true;
                _currentPillar--;
                _currentPillar = _currentPillar < 0 ? _pillars.Length - 1 : _currentPillar;
            }
        UpdatePosition();
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        if(Time.timeScale == 1)
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
    private void UpdatePosition()
    {
        var currentPillar = _pillars[_currentPillar];
        var currentPosition = _isRight ? currentPillar.rightTransform : currentPillar.leftTransform;
        transform.SetPositionAndRotation(currentPosition.position, currentPosition.rotation);
        _camara.transform.SetPositionAndRotation(currentPillar.transform.position, currentPillar.transform.rotation);
    }
}



