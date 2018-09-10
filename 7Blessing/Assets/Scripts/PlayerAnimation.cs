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

        bool runningRight = Input.GetKey(KeyCode.D);
        bool runningLeft = Input.GetKey(KeyCode.A);
        bool jumpingRight = Input.GetKey(KeyCode.Space);

        mAnimator.SetBool("RunningRight", runningRight);
        mAnimator.SetBool("RunningLeft", runningLeft);
        mAnimator.SetBool("JumpingRight", jumpingRight);
    }
}
