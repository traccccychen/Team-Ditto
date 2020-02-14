using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChildCell : Cell
{
    public float speed = 1.5f;
    float JoyStickB;
    Transform Destination;
    public string joystick2;

    // Update is called once per frame
    void Start() 
    {
        if (joystick2 == null)
        {
            joystick2 = "joystick 1";
        }
    }
    void Update()
    {
         
    }
    
    private void OnCollisionStay(Collision other) 
    {
        
    }
       
    
}
