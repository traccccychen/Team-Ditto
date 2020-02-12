using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    
    
    public GameObject CellObject;
    public GameObject ObjectToFollow;
    Vector3 OriginalScale;
    Vector3 previous;
    public Rigidbody rb;
  
  private bool isGrounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        OriginalScale = this.transform.localScale;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("JoyStickA")!= 0)
        {
            LazyFollow(ObjectToFollow.transform.position);
        }
        
        //split
        if (Input.GetKeyDown("space"))
        {
            GameObject newCell = Instantiate(CellObject, this.transform.position,this.transform.rotation);
            this.transform.localScale = OriginalScale/1.3f;
            OriginalScale = this.transform.localScale;
            newCell.transform.localScale = this.transform.localScale;
            
        }
        //change scale
        Stretching();
        

        if (Input.GetKeyDown("joystick button 0") && isGrounded)
        {
            isGrounded = false;
            rb.useGravity = false;
            Jump();
        }
        
    }

    void Stretching()
    {
        var velocity = (this.transform.position - previous) / Time.deltaTime;
        this.transform.localScale = new Vector3 (Mathf.Abs(velocity.x/30),
                                                 Mathf.Abs(velocity.y/30),
                                                 Mathf.Abs(velocity.z/30)
                                                ) + OriginalScale;
        previous = this.transform.position;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        
    }

    void LazyFollow(Vector3 Destination)
    {
        this.transform.DOMoveX(Destination.x,1f);
        Vector3 Direction = (Destination - this.transform.position).normalized;
        Direction.z =0;
        
        Quaternion XLookRotation = Quaternion.LookRotation(Destination, transform.up) * Quaternion.Euler(new Vector3(0, 90, 0));
            
    }

    void Jump()
    {
        this.transform.DOJump(this.transform.position+new Vector3 (Input.GetAxisRaw("JoyStickA")*3,0,0),2,1,1f,false).OnComplete
        (
            ()=> 
            {
                rb.useGravity = true;
            }
        );
    }

    void Merge()
    {

    }


}
