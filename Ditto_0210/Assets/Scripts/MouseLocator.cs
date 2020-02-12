using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocator : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mousePosition;
    float zAxis = 2f;
    float JoystickA;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, zAxis);
        //this.transform.position = mousePosition;
        JoystickA = Input.GetAxisRaw("JoyStickA");
        transform.Translate(Vector3.right * Time.deltaTime*JoystickA*4);
    }
}
