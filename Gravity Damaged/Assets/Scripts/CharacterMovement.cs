using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform[] leftPath1;
    public Transform[] rigthPath1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)) { StartCoroutine(followRight1()); }
        if(Input.GetKeyDown(KeyCode.LeftArrow)) { StartCoroutine(followLeft1()); }
    }
    IEnumerator followRight1() 
    {
        foreach(Transform waypoint in rigthPath1)
        {
            yield return StartCoroutine(Move(waypoint.position,10));
        }
    }

    IEnumerator followLeft1()
    {
        foreach(Transform waypoint in leftPath1)
        {
            yield return StartCoroutine(Move(waypoint.position, 10));
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
