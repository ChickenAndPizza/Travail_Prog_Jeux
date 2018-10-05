using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private float timeBetweenAttack;
    [SerializeField] float startTimeBetweenAttack;
    [SerializeField] Rigidbody2D player;

    [SerializeField] Transform attackPos;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask whatIsEnemies;
    [SerializeField] Animator playerAnim; 
	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(timeBetweenAttack <= 0)
        {
            if (Input.GetAxis("Fire1") > 0)
            {
                if(player.velocity.x != 0)
                {
                    playerAnim.Play("PlayerRunningAttack");
                }
                else
                {
                    playerAnim.Play("PlayerAttack");
                }
                Collider2D[] ennemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                timeBetweenAttack = startTimeBetweenAttack;
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
