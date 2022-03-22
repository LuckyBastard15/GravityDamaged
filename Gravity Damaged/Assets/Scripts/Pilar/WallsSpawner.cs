using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class WallsSpawner : MonoBehaviour
{
    public List<GameObject> AllWalls;
    private float offset = 22f;

    void Start()
    {
        if (AllWalls != null && AllWalls.Count > 0)
        {
            AllWalls = AllWalls.OrderBy(n => n.transform.position.y).ToList(); 
        }

    }

    public void MoveWalls()
    {
        GameObject movedWalls = AllWalls[0];
        AllWalls.Remove(movedWalls);
        float newY = AllWalls[AllWalls.Count - 1].transform.position.y + offset;
        movedWalls.transform.position = new Vector3(0, newY, 0);
        AllWalls.Add(movedWalls);

    }
}
