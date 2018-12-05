using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAttack : MonoBehaviour {
    int attack;
	// Use this for initialization
	void Start () {
        attack = GetComponentInParent<Boss>().attack;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Attackable attackable = collision.gameObject.GetComponent<Attackable>();
        if (attackable != null)
        {
            attackable.Attacked(attack);
        }

    }
}
