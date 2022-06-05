using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    private int _currentPillar = 0;
    private bool _isRight = true;

    [SerializeField] private Transform _camera = null;
    [SerializeField] private Pillar[] _pillars = null;
    [SerializeField] private Animator _animLooseMenu = default;
    [SerializeField] private Animator _animLoosePlayer = default;
    [SerializeField] private ParticleSystem _crash = default;
    [SerializeField] private AudioSource _loseSource;
    [SerializeField] private AudioClip _loseSound;
    [SerializeField] private AudioSource _leftSource;
    [SerializeField] private AudioClip _leftSound;
    [SerializeField] private AudioSource _rightSource;
    [SerializeField] private AudioClip _rightSound;

    private void Start()
    {
        UpdatePosition();
        _crash = GetComponent<ParticleSystem>();
        _loseSource = GetComponent<AudioSource>();
        _leftSource = GetComponent<AudioSource>();
        _rightSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
            _rightSource.PlayOneShot(_rightSound, 1f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
            _leftSource.PlayOneShot(_leftSound, 1f);
        }
    }

    public void MoveRight()
    {
        _rightSource.PlayOneShot(_rightSound, 1f);
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
        _leftSource.PlayOneShot(_leftSound, 1f);
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
            _crash.Play();
            _loseSource.PlayOneShot(_loseSound, 1f);
            Time.timeScale = 0;
            _animLoosePlayer.SetTrigger("Dead");
            StartCoroutine(Crash());
        }
    }

    public IEnumerator Crash()
    {
        yield return new WaitForSecondsRealtime(1.25f);
        _animLooseMenu.SetTrigger("Loose");
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
