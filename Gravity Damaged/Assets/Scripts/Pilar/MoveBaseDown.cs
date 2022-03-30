using UnityEngine;

public class MoveBaseDown : MonoBehaviour
{
    private float _speed = 8;
    
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
