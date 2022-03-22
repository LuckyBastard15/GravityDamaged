using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBaseDown : MonoBehaviour
{

    private float speed = 3;
    private GameObject respawnPoint;

    void Start()
    {

    }
    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

     
    }
}
