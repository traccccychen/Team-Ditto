using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    
    
    public GameObject CellObject;
    Vector3 OriginalScale;
    Vector3 previous;
    public Rigidbody rb;
    float JoyStickA;
    public string joystick;
  
    public bool isGrounded = true;
    public bool FinishJump = true;
    protected int NumOfPlayer = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        OriginalScale = this.transform.localScale;
        rb = this.GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        JoyStickA = Input.GetAxisRaw(joystick);
        if (Input.GetAxisRaw(joystick)!= 0 && FinishJump)
        {
            LazyFollow(this.transform.position + Vector3.right * Time.deltaTime*JoyStickA*40);
        }
        
        //split
        if (Input.GetKeyDown(joystick + " button 2"))
        {
            Split();
        }
        
        //change scale
        Stretching();
        

        if (Input.GetKeyDown(joystick + " button 0") && isGrounded)
        {
            isGrounded = false;
            FinishJump = false;
            rb.useGravity = false;
            StartCoroutine(Jump());
        }
        
    }

    public void Stretching()
    {
        var velocity = (this.transform.position - previous) / Time.deltaTime;
        if (velocity.x>10) velocity.x = 10;
        else if (velocity.x<-10) velocity.x = -10;
        if (velocity.y>10) velocity.y = 10;
        else if (velocity.y<-10) velocity.y = -10;
        if (velocity.z>10) velocity.z = 10;
        else if (velocity.z<-10) velocity.z = -10;
        this.transform.localScale = new Vector3 (Mathf.Abs(velocity.x/30),
                                                 Mathf.Abs(velocity.y/30),
                                                 Mathf.Abs(velocity.z/30)
                                                ) + OriginalScale;
        previous = this.transform.position;
    }
    

    public void LazyFollow(Vector3 Destination)
    {
        this.transform.DOMoveX(Destination.x,1f);
        Vector3 Direction = (Destination - this.transform.position).normalized;
        Direction.z =0;
        Quaternion XLookRotation = Quaternion.LookRotation(Destination, transform.up) * Quaternion.Euler(new Vector3(0, 90, 0));
            
    }

    public IEnumerator Jump()
    {
        this.transform.DOJump(this.transform.position+new Vector3 (Input.GetAxisRaw(joystick)*3,0,0),2*this.transform.localScale.x,1,1f,false).OnComplete
        (
            ()=> 
            {
                rb.useGravity = true;
                isGrounded = true;
            }
        );
        yield return new WaitForSeconds(0.6f);
        FinishJump = true;
    }

    protected void Split()
    {
        if (this.transform.localScale.x>0.4f && this.transform.localScale.y>0.4f &&this.transform.localScale.z>0.4f)
        {
            CellManager.instance.PlayerNumber ++;
            GameObject newCell = Instantiate(CellObject, this.transform.position,this.transform.rotation);
            newCell.GetComponent<Cell>().joystick = "joystick " + CellManager.instance.PlayerNumber.ToString();
            this.transform.localScale = OriginalScale/1.3f;
            OriginalScale = this.transform.localScale;
            newCell.transform.localScale = this.transform.localScale*0.8f;
            newCell.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag == "Cell")
        {
            if (Input.GetKey(joystick + " button 3"))
            {
                Merge(other.gameObject);
            }
        }
    }
    protected void Merge(GameObject EatenCell)
    {
        if (this.transform.localScale.x > EatenCell.transform.localScale.x)   
        { 
            CellManager.instance.PlayerNumber --;
            Destroy(EatenCell);
            this.transform.localScale = OriginalScale*1.3f;
            OriginalScale = this.transform.localScale;
        }
    }


}
