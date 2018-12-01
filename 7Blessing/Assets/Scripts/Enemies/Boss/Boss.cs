using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemies, Attackable {

    Animator mAnimator;
    public ParticleSystem BossDeath;

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
        StartCoroutine(Flash());
        if (((float)health / (float)maxHealth) < 0.25f)
        {
            mAnimator.SetTrigger("TriggerPhase3Idle");
        }else if (((float)health / (float)maxHealth) < 0.75f)
        {
            mAnimator.SetTrigger("TriggerPhase2Idle");
        }
        if (health <= 0)
        {
            Instantiate(BossDeath, gameObject.transform);
            mAnimator.SetTrigger("Death");
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

    public void TransitionToPhase2()
    {
        Player_Move_Prot player = FindObjectOfType<Player_Move_Prot>();
        mAnimator.SetTrigger("StartPhase2");
        player.EnableControl();
    }

    void FlashBoss()
    {
        SpriteRenderer  renderer = GetComponent<SpriteRenderer>();
        renderer.material.SetFloat("_FlashAmount", 0.8f);
    }
    IEnumerator Flash()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.material.SetFloat("_FlashAmount", 0.8f);
        yield return new WaitForSeconds(0.1f);
        renderer.material.SetFloat("_FlashAmount", 0f);
        yield return new WaitForSeconds(0.1f);
        renderer.material.SetFloat("_FlashAmount", 0.8f);
        yield return new WaitForSeconds(0.1f);
        renderer.material.SetFloat("_FlashAmount", 0f);
    }
    public void KillBoss()
    {
        Destroy(gameObject);
    }
}
