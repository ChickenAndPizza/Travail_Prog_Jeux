using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShuriken : MonoBehaviour {
    private AudioSource audioSource;
    private bool isUnlocked = false;
    [SerializeField] float timeOut = 1;
    [SerializeField] GameObject shuriken;
    [SerializeField] GameObject emmiter;
    Animator playerAnim;
    [SerializeField] AudioClip attackSound;
    private float timeLastFired = 1;
    private int facingDirection = 0;
	// Use this for initialization
	void Start () {
        playerAnim = GetComponentInParent<Animator>();
        audioSource = GetComponent<AudioSource>();
        isUnlocked = GetComponentInParent<PlayerStats>().shurikenUnlocked;
    }
	
	// Update is called once per frame
	void Update () {
        timeLastFired += Time.deltaTime;
        if(GetComponentInParent<Player_Move_Prot>().facingLeft)
        {
            facingDirection = -1;
        }
        else
        {
            facingDirection = 1;
        }

		if(Input.GetAxis("Fire3") != 0 && timeLastFired >= timeOut && isUnlocked)
        {
            GameObject shurikenObject = Instantiate(shuriken, emmiter.transform.position, emmiter.transform.rotation);
            shurikenObject.GetComponent<Shuriken>().direction = facingDirection;
            playerAnim.Play("PlayerThrowShuriken");
            audioSource.PlayOneShot(attackSound);
            timeLastFired = 0;
        }
	}
}
