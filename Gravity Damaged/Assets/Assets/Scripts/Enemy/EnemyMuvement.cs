using UnityEngine;

public class EnemyMuvement : MonoBehaviour
{
    [SerializeField] private float _speed = 0;

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}
