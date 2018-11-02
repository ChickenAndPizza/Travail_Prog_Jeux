using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Move_Prot : MonoBehaviour {

    private int playerSpeed;
    private int playerJumpPower;
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
    private AudioSource mAudioSource;
    public AudioClip groundedSound;
    // Use this for initialization
    void Start()
    {
        if(SceneManager.GetActiveScene().name != "FirstScene")
        {
            DontDestroyOnLoad(gameObject);
        }
        mPlayerBody = GetComponent<Rigidbody2D>();
        mAudioSource = GetComponent<AudioSource>();
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerSpeed = GetComponent<PlayerStats>().speed;
        playerJumpPower = GetComponent<PlayerStats>().jumpPower;
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
            mAudioSource.PlayOneShot(groundedSound);
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
                    direction = new Vector2(-.5f,0);
                }
                else
                {
                    direction = new Vector2(0.5f,0);
                }

                ContactFilter2D contactFilter2DInteraction = BuildContactFilter2DForLayer("Interaction");
                RaycastHit2D[] interactionHit = new RaycastHit2D[16];
                int interactionCollisionHitCount = Physics2D.Raycast(gameObject.transform.position, direction, contactFilter2DInteraction, interactionHit, .5f);
                List<RaycastHit2D> hitBufferListInteraction = BufferArrayHitToList(interactionHit, interactionCollisionHitCount);
                if (hitBufferListInteraction.Count > 0)
                {
                    hitBufferListInteraction[0].transform.gameObject.GetComponent<Interaction>().Interact();
                }
            }
        }
        else
        {
            eIsPressed = false;
        }
    }


    private ContactFilter2D BuildContactFilter2DForLayer(string LayerName)
    {
        ContactFilter2D contactFilter2DInteraction = new ContactFilter2D();
        contactFilter2DInteraction.useTriggers = false;
        contactFilter2DInteraction.SetLayerMask(Physics2D.GetLayerCollisionMask(LayerMask.NameToLayer(LayerName)));
        contactFilter2DInteraction.useLayerMask = true;
        return contactFilter2DInteraction;
    }

    private List<RaycastHit2D> BufferArrayHitToList(RaycastHit2D[] hitBuffer, int count)
    {
        List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(count);
        hitBufferList.Clear();
        for (int i = 0; i < count; i++)
        {
            hitBufferList.Add(hitBuffer[i]);
        }
        return hitBufferList;
    }
}
