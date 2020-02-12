using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCell : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //   if (Input.GetKey(KeyCode.A))
    //  {
    //      transform.position += Vector3.left * speed * Time.deltaTime;
    //  }
    //  if (Input.GetKey(KeyCode.D))
    //  {
    //      transform.position += Vector3.right * speed * Time.deltaTime;
    //  }
    //  if (Input.GetKey(KeyCode.W))
    //  {
    //      transform.position += Vector3.up * speed * Time.deltaTime;
    //  }
    //  if (Input.GetKey(KeyCode.S))
    //  {
    //      transform.position += Vector3.down * speed * Time.deltaTime;
    //  }
    // }
    Rigidbody rb = GetComponent<Rigidbody>();
         if (Input.GetKey(KeyCode.A))
             rb.AddForce(Vector3.left);
         if (Input.GetKey(KeyCode.D))
             rb.AddForce(Vector3.right);
         if (Input.GetKey(KeyCode.W))
             rb.AddForce(Vector3.up);
         if (Input.GetKey(KeyCode.S))
             rb.AddForce(Vector3.down);
            // Debug.Log(rb.velocity);
    }
}
