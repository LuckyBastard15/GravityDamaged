using UnityEngine;
using DG.Tweening;

public class CharacterMovement : MonoBehaviour
{
    private int _currentPillar = 0;
    private bool _isRight = true;

    [SerializeField] private Transform _camera = null;
    [SerializeField] private GameObject _player = default;
    [SerializeField] private GameObject _looseMenu = null;
    [SerializeField] private Pillar[] _pillars = null;

    private void Start()
    {
        UpdatePosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
    }

    public void MoveRight()
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

    public void MoveLeft()
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            _player.SetActive(false);
            if (_player.activeInHierarchy == false)
            {
                Time.timeScale = 0;
                _looseMenu.SetActive(true);
            }
        }
    }

    private void UpdatePosition()
    {
        var currentPillar = _pillars[_currentPillar];
        var currentPosition = _isRight ? currentPillar.rightTransform : currentPillar.leftTransform;
        transform.rotation = currentPosition.rotation;
        transform.DOMove(currentPosition.position, 0.6f).SetEase(Ease.InOutSine);
        var currentPosCamera = _isRight ? currentPillar.rightCameraTransform : currentPillar.leftCameraTransform;
        _camera.transform.DOMove(currentPosCamera.position, 0.8f).SetEase(Ease.InOutSine);  
        _camera.transform.DORotate(currentPosCamera.eulerAngles, 0.8f).SetEase(Ease.InOutSine);
    }
}
