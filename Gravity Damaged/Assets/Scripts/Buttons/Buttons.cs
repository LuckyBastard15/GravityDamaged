using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buttons : MonoBehaviour
{
    public UnityEvent buttonClick;
    public CharacterTest MoveR { get; }

    private void Awake()
    {
        if(buttonClick == null) {   }
    }

}
