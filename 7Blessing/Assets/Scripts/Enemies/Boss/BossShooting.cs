using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour {

    public GameObject projectile;
    public Transform projectileEmitter;


    private Transform Player;
    private Vector3 target;
    // Use this for initialization
    void Start () {
		
	}

    public void Shoot()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = Player.position;
        Vector3 direction = target - projectileEmitter.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        Instantiate(projectile, projectileEmitter.transform.position, rotation);
    }
}
