using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateBase : MonoBehaviour
{
    WallsSpawner wallsSpawner;

    private void Start()
    {
        wallsSpawner = GetComponent<WallsSpawner>();
    }

    public void SpawnTriggerEntered()
    {
        wallsSpawner.MoveWalls(); 
    }
}
