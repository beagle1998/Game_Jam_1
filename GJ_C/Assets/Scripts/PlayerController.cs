using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    bool jump = false, Grounded;
    int j_counter = 0;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"),0);
        moveVelocity = moveInput.normalized * speed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void IsGrounded() { 
        Grounded = true;
    }
    void NotGrounded()
    {
        Grounded = false;
    }

    Vector2 JumpMove(Vector2 v)
    {
        Vector2 InputJump = new Vector2(0,10f);
        InputJump= InputJump+v;
        return InputJump;
    }



    private void FixedUpdate()
    {
        if (jump)
        {
           moveVelocity=JumpMove(moveVelocity);
           jump = false;
        }
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }


}
