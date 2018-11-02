using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPosition : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask endingLayer;
    Player_Move_Prot movement;
    Rigidbody2D rigidBody2D;
    // Use this for initialization
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = gameObject.transform.position;
        rigidBody2D = player.GetComponent<Rigidbody2D>();
        rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
        movement = player.GetComponent<Player_Move_Prot>();
        movement.GroundCheck = GroundCheck;
        movement.groundLayer = groundLayer;
    }
}
