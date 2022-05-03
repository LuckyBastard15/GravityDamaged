using UnityEngine;

public class triggerSpawnWalls : MonoBehaviour
{
    [SerializeField] private DuplicateBase _duplicateBase = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrigger"))
        {
            _duplicateBase.SpawnTriggerEntered();
        }
    }
}
    