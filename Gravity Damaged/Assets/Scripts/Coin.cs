using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _coin = default;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Jugador"))
        {
            _coin.SetActive(false);
            Score._instance.AddPoint();
        }
    } 
}
