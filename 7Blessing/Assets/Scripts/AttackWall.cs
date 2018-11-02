using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWall : MonoBehaviour, Attackable {
    private AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
    public void Attacked(int damage)
    {
        audioSource.PlayOneShot(audioClip);
    }
    

    public void Heal(int healPower)
    {
        
    }
}
