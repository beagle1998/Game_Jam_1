

}
    public float checkRadius;
    public LayerMask whatIsGround;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Check collision of a "groundcheck" cirle with "checkRadius" size at the player's feet, comparing the collision with what Layer we set as ground.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        Debug.Log("moveInput"); // prints to a console what value moveInput is / helpful for "looking under the hood"
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }


    }

    private void Update()
    {
        if(isGrounded == true)
        {
            jumps = extraJumps;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
            }

        }
    }

    //private void FixedUpdate() //more consistent with physics proccesses , view https://stackoverflow.com/questions/34447682/what-is-the-difference-between-update-fixedupdate-in-unity
    //{
    //rb.MovePosition(rb.position + moveInput * Time.fixedDeltaTime);
    //}

    void Flip() // flips character sprite
    {
        // playerScale represents the "transform by scaling" window in the Player's sprite component.
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }


}
