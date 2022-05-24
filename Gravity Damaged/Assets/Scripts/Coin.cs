using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _coin = default;
    [SerializeField] private ParticleSystem _conffeti;

    private void Start()
    {
        _conffeti = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            _conffeti.Play();
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