using UnityEngine;

public class MoveBaseDown : MonoBehaviour
{
    private readonly float _speed = 8;
    
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);
    }
}
