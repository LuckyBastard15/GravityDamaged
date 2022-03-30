using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject _coin = default; 
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Jugador")
        {
            _coin.SetActive(false);
        }
    }
}
