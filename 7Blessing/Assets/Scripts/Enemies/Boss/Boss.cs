using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemies, Attackable {

    Animator mAnimator;

    // Use this for initialization
    void Start () {
        mAnimator = GetComponent<Animator>();
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

    public void Attacked(int damage)
    {
        health -= damage;
        if (((float)health / (float)maxHealth) < 0.25f)
        {
            mAnimator.SetTrigger("TriggerPhase3Idle");
        }else if (((float)health / (float)maxHealth) < 0.75f)
        {
            mAnimator.SetTrigger("TriggerPhase2Idle");
        }
        if (health < 0)
        {
            health = 0;
        }
    }

    public void Heal(int healPower)
    {
        health += healPower;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void IntroFight()
    {
        Player_Move_Prot player = FindObjectOfType<Player_Move_Prot>();
        mAnimator.SetTrigger("StartFight");
        player.EnableControl();
    }
}
