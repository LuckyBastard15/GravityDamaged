using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CharacterTest : MonoBehaviour
{
    public Pillar[] _pillars = null;

    private int _currentPillar = 0;
    private bool _isRight = false;
    private bool _isLeft = false;

    public DuplicateBase duplicateBase;


    private void Start()
    {
        UpdatePositionR();
        UpdatePositionL();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveR(true);
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            MoveL(true);
           
        }
        


    }
    private void OnTriggerEnter(Collider other)
    {
        duplicateBase.SpawnTriggerEntered();
    }

    private void MoveR(bool goingRight)
    {

        if (goingRight)
        {

            if (_isRight)
            {
                _currentPillar++;
                _currentPillar = _currentPillar >= _pillars.Length ? 0 : _currentPillar;

                _isRight = false;
            }
            else
            {
                _isRight = true;
            }

        }
        
        UpdatePositionR();
    }

    private void MoveL(bool goingLeft)
    {
            if (_isLeft)
            {
                _currentPillar--;
                _currentPillar = _currentPillar < 0 ? _pillars.Length - 1 : _currentPillar;


                _isLeft = false;
            }
            else
            {
                _isLeft = true;
            }
        UpdatePositionL();


    }


    private void UpdatePositionR()
    {
        var currentPillar = _pillars[_currentPillar];
        var currentPosition = _isRight ? currentPillar.rightTransform : currentPillar.leftTransform;
        transform.position = currentPosition.position;

    }
    private void UpdatePositionL()
    {
        var currentPillar = _pillars[_currentPillar];
        var currentPosition = _isLeft ? currentPillar.leftTransform : currentPillar.rightTransform;
        transform.position = currentPosition.position;

    }

}



