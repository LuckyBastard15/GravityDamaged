using UnityEngine;

public class DuplicateBase : MonoBehaviour
{
    [SerializeField]private WallsSpawner _wallsSpawner = default;

    private void Start()
    {
        _wallsSpawner = GetComponent<WallsSpawner>();
    }

    public void SpawnTriggerEntered()
    {
        _wallsSpawner.MoveWalls(); 
    }
}
