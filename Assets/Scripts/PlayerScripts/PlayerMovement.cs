using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public characterController controller;
    public float runSpeed = 40.0f;
    float horizontalMove = 0.0f;
    bool jump = false;
    bool dash = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            dash = true;
        }
    }

    public void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
        jump = false;
        dash = false;
    }
}

