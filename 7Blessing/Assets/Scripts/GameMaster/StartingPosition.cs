using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartingPosition : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask endingLayer;
    Player_Move_Prot movement;
    Rigidbody2D rigidBody2D;
    CameraShake cameraShake;
    // Use this for initialization
    private void Awake()
    {
        print("test");
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = gameObject.transform.position;
        rigidBody2D = player.GetComponent<Rigidbody2D>();
        if(SceneManager.GetActiveScene().name != "FirstScene")
        {
            rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
        }
        movement = player.GetComponent<Player_Move_Prot>();
        movement.GroundCheck = GroundCheck;
        movement.groundLayer = groundLayer;
        cameraShake = player.GetComponent<CameraShake>();
        cameraShake.mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
}
