using UnityEngine;

public class EnemyMuvement : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    void Update()
    {
        transform.Translate(Vector3.down *_speed *Time.deltaTime);
    }
}
