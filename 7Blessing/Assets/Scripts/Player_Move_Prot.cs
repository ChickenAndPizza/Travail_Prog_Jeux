using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour {

    public int playerSpeed = 10;
    public int playerJumpPower = 500;
    public float moveX = 2;
    public bool grounded = false;
    public bool facingRight = true;
    private bool jumping = false;
    private bool running = false;
    private Animator mAnimator;
        // Use this for initialization
        void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump")!= 0 && grounded)
        {
            Jump();
            grounded = false;
        }
        mAnimator.SetBool("Grounded", grounded);
        if(Input.GetAxis("Horizontal") != 0)
        {
            running = true;
            MovePlayer();
        }
        else
        {
            running = false;
        }
        mAnimator.SetBool("Running", running);
        mAnimator.SetBool("JumpingRight", jumping);
    }

    void MovePlayer()
    {
        moveX = Input.GetAxis("Horizontal");
        if (moveX < 0.0f && !facingRight)
        {
            FlipPlayer();
        }
        else if(moveX > 0.0f && facingRight)
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        mAnimator.SetFloat("VelocityY", gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if(mAnimator.GetFloat("VelocityY") != 0)
        {
            grounded = false;
        }
        else
        {
            grounded = true;
        }
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localscale = gameObject.transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        jumping = true;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            jumping = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
