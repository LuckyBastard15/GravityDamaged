using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _coin = default;
    [SerializeField] private ParticleSystem _conffeti;
    [SerializeField] private AudioSource _coinSourse;
    [SerializeField] private AudioClip _coinSound;

    private void Start()
    {
        _conffeti = GetComponent<ParticleSystem>();
        _coinSourse = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            _conffeti.Play();
            _coinSourse.PlayOneShot(_coinSound, 1f);
            StartCoroutine(Conffeti());
            
        }
    }
    public IEnumerator Conffeti()
    {
        yield return new WaitForSeconds(0.15f);
        _coin.SetActive(false);
        Score.Instance.AddPoint();
    }
}