using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Move_Prot : MonoBehaviour {

    public int playerSpeed = 10;
    public int playerJumpPower = 7;
    public float moveX = 0;
    public bool grounded = false;
    public bool facingLeft = false;
    private bool jumping = false;
    private bool running = false;
    private bool controlAreEnable = true;
    public Transform GroundCheck;
    public LayerMask groundLayer;
    public LayerMask endingLayer;
    public bool eIsPressed = false;
    private Animator mAnimator;
    private Rigidbody2D mPlayerBody;
    // Use this for initialization
    void Start()
    {
        if(SceneManager.GetActiveScene().name != "FirstScene")
        {
            DontDestroyOnLoad(gameObject);
        }
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

        mAnimator.SetBool("Grounded", grounded);
        mAnimator.SetBool("JumpingRight", jumping);
        mAnimator.SetBool("Running", running);
    }

    void MovePlayer()
    {
        moveX = Input.GetAxis("Horizontal");
        if (moveX < 0.0f && !facingLeft)
        {
            FlipPlayer();
        }
        else if(moveX > 0.0f && facingLeft)
        {
            FlipPlayer();
        }
        if ((moveX < 0.0f && checkLeft()) || (moveX > 0.0f && checkRight()))
        {
            moveX = 0.0f;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        mAnimator.SetFloat("VelocityY", mPlayerBody.velocity.y);
    }

    bool checkRight()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.right;
        float distance = 0.3f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    bool checkLeft()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.left;
        float distance = 0.3f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
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
        facingLeft = !facingLeft;
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
                Vector2 direction = new Vector2();
                if (facingLeft == true)
                {
                    direction = Vector2.left;
                }
                else
                {
                    direction = Vector2.right;
                }

                if(Physics2D.Raycast(transform.position, direction, 0.5f, endingLayer))
                {
                    GameObject endingScene = GameObject.FindWithTag("EndingScene");
                    if (endingScene != null)
                    {
                        EndingSceneDialog interact = endingScene.GetComponent<EndingSceneDialog>();
                        interact.Interact();
                    }
                }
            }
        }
        else
        {
            eIsPressed = false;
        }
    }
}
