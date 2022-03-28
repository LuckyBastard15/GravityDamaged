using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CharacterTest : MonoBehaviour
{
    public Pillar[] _pillars = null;

    private int _currentPillar = 0;
    private bool _isRight = true;

    public Transform camara;
    public DuplicateBase duplicateBase;

    //public Buttons buttonClick;


    private void Start()
    {
        UpdatePosition();
       
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveR();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveL();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        duplicateBase.SpawnTriggerEntered();
    }

    public void MoveR()
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
        UpdatePosition();
    }

    public void MoveL()
    {

            if (_isRight)
            {
                _isRight = false;
            }
            else
            {
                _isRight = true;

                _currentPillar--;
                _currentPillar = _currentPillar < 0 ? _pillars.Length - 1 : _currentPillar;

            }
        UpdatePosition();
    }


    private void UpdatePosition()
    {
        var currentPillar = _pillars[_currentPillar];
        var currentPosition = _isRight ? currentPillar.rightTransform : currentPillar.leftTransform;
        transform.position = currentPosition.position;

        camara.transform.position = currentPillar.transform.position;
        camara.transform.rotation = currentPillar.transform.rotation;

    }
    

}



