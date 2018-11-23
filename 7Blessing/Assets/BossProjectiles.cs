using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectiles : MonoBehaviour {
    public float speed;
    private GameObject player;
    private Transform target;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * speed * Time.deltaTime ;
    }
}
