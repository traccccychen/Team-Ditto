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
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKeyDown(joystick2 + " button 0") && isGrounded)
        {
            isGrounded = false;
            rb.useGravity = false;
            StartCoroutine(Jump());
        }
        
        JoyStickB = Input.GetAxisRaw(joystick2);
         
        if (Input.GetAxisRaw(joystick2)!=0 && FinishJump)
        {
            LazyFollow(this.transform.position + Vector3.right * Time.deltaTime* JoyStickB * 40);
        }
        //change scale
        Stretching();

        if (Input.GetKeyDown(joystick2 + " button 2"))
        {
            Split();
        }     
    }
    
    private void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag == "Cell")
        {
            Debug.Log("Child eat collide");
            if (Input.GetKey(joystick2 + " button 3"))
            {
                Debug.Log("button 3");
                Merge(other.gameObject);
            }
        }
    }
       
    
}
