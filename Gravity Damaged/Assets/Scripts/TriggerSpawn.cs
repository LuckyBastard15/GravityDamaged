using UnityEngine;

public class TriggerSpawn : MonoBehaviour
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

