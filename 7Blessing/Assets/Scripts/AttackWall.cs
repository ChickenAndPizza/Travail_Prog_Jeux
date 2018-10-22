using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWall : Attackable {
    private AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
    public override void Attacked()
    {
        audioSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
