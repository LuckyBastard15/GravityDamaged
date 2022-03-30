using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallsSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> _AllWalls;
    private float _offset = 66f;

    void Start()
    {
        if (_AllWalls != null && _AllWalls.Count > 0)
        {
            _AllWalls = _AllWalls.OrderBy(n => n.transform.position.y).ToList(); 
        }
    }

    public void MoveWalls()
    {
        GameObject movedWalls = _AllWalls[0];
        _AllWalls.Remove(movedWalls);
        float newY = _AllWalls[_AllWalls.Count - 1].transform.position.y + _offset;
        movedWalls.transform.position = new Vector3(0, newY, 0);
        _AllWalls.Add(movedWalls);
    }
}
