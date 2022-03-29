using UnityEngine;

public class DuplicateBase : MonoBehaviour
{
    public WallsSpawner _wallsSpawner = null;

    private void Start()
    {
        _wallsSpawner = GetComponent<WallsSpawner>();
    }

    public void SpawnTriggerEntered()
    {
        _wallsSpawner.MoveWalls(); 
    }
}
