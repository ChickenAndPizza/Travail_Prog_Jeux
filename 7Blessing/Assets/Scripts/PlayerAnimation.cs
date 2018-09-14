using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator mAnimator;
	// Use this for initialization
	void Start () {
        mAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        bool running;
        if(Input.GetAxis("Horizontal") !=0 )
        {
            running = true;
        }
        else
        {
            running = false;
        }
        bool jumpingRight = Input.GetKey(KeyCode.Space);
        
        mAnimator.SetBool("Running", running);
        mAnimator.SetBool("JumpingRight", jumpingRight);
    }
}
