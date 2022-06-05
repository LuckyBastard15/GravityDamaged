using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject _enemyToDestroy = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroyer"))
        {
            _enemyToDestroy.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
