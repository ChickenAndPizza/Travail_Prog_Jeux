using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDamage : MonoBehaviour,Attackable {
    Boss theBoss;

    public void Attacked(int damage)
    {
        theBoss.Attacked(damage);
    }

    public void Heal(int healPower)
    {
        theBoss.Heal(healPower);
    }

    // Use this for initialization
    void Start () {
        theBoss = GetComponentInParent<Boss>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
