using UnityEngine;

public class EnemyMuvement : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    //[SerializeField] private float _speed = 13;
    void Update()
    {
        transform.Translate(Vector3.down *_speed *Time.deltaTime);
    }
}
