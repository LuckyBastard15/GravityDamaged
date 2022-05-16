using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conffeti : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Confetti");
        }
    }
}
