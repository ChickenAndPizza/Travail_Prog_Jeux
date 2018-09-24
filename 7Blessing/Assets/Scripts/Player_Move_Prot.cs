using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour {

    public int playerSpeed = 10;
    public int playerJumpPower = 7;
    public float moveX = 0;
    public bool grounded = false;
    public bool facingRight = true;
    private bool jumping = false;
    private bool running = false;
    private bool controlAreEnable = true;
    public Transform GroundCheck;
    public LayerMask groundLayer;
    public bool eIsPressed = false;
    private Animator mAnimator;
    private Rigidbody2D mPlayerBody;
    // Use this for initialization
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mPlayerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = IsGrounded();
        if (controlAreEnable)
        {
            if (Input.GetAxis("Jump")!= 0 && grounded)
            {
                Jump();
            }
            if(Input.GetAxis("Horizontal") != 0)
            {
                running = true;
                MovePlayer();
                ManageInteraction();
            }
            else
            {
                running = false;
            }

        }

        mAnimator.SetBool("Running", running);
        mAnimator.SetBool("Grounded", grounded);
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
        
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if(hit.collider != null)
        {
            return true;
        }
        return false;
        // Vector3 vector = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        // Debug.DrawRay(vector, Vector3.down,Color.red);
        // int numberOfCollision = mPlayerBody.Cast(Vector2.down * 0.05f, results);
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
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, playerJumpPower);
        jumping = true;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumping = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void DisableControl()
    {
        this.controlAreEnable = false;
        this.moveX = 0;
    }

    public void EnableControl()
    {
        this.controlAreEnable = true;
    }

    private void ManageInteraction()
    {
        if (Input.GetAxis("E") != 0)
        {
            if (!eIsPressed)
            {
                eIsPressed = true;

                //ContactFilter2D contactFilter2DInteraction = BuildContactFilter2DForLayer("Interaction");
                //RaycastHit2D[] interactionHit = new RaycastHit2D[16];
                //int interactionCollisionHitCount = Physics2D.Raycast(gameObject.transform.position, Vector2.up, contactFilter2DInteraction, interactionHit);
                //List<RaycastHit2D> hitBufferListInteraction = BufferArrayHitToList(interactionHit, interactionCollisionHitCount);
                //if (hitBufferListInteraction.Count > 0)
                //{
                //    hitBufferListInteraction[0].transform.gameObject.GetComponent<Interaction>().Interact();
                //}
            }
        }
        else
        {
            eIsPressed = false;
        }
    }
}
