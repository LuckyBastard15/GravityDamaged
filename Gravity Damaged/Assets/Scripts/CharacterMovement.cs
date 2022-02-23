using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform[] leftPath;
    public Transform[] rigthPath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)) { StartCoroutine(followRight()); }
        if(Input.GetKeyDown(KeyCode.LeftArrow)) { StartCoroutine(followLeft()); }
    }
    IEnumerator followRight() 
    {
        foreach(Transform waypoint in rigthPath)
        {
            StartCoroutine(Move(waypoint.position, 8));
            yield return 0;
        }
    }

    IEnumerator followLeft()
    {
        foreach(Transform waypoint in leftPath)
        {
            StartCoroutine(Move(waypoint.position, 8));
            yield return 0;
        }
    }

    IEnumerator Move(Vector3 destination, float speed = 10 )
    {
        while(transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return 0;
        }
    }
}
