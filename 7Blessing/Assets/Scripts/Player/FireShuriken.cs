using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShuriken : MonoBehaviour {
    private AudioSource audioSource;
    private bool isUnlocked = false;
    [SerializeField] float timeOut = 1;
    [SerializeField] GameObject shuriken;
    [SerializeField] GameObject emmiter;
    [SerializeField] Animator playerAnim;
    [SerializeField] AudioClip attackSound;
    private float timeLastFired = 1;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        isUnlocked = GetComponentInParent<PlayerStats>().shurikenUnlocked;
    }
	
	// Update is called once per frame
	void Update () {
        timeLastFired += Time.deltaTime;
		if(Input.GetAxis("Fire3") != 0 && timeLastFired > timeOut && isUnlocked)
        {
            Instantiate(shuriken, emmiter.transform.position, emmiter.transform.rotation);
            playerAnim.Play("PlayerThrowShuriken");
            audioSource.PlayOneShot(attackSound);
            timeLastFired = 0;
        }
	}
}
