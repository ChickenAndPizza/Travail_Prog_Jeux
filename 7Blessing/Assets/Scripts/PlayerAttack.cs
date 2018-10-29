using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, Attackable{

    private float timeBetweenAttack = 0;
    private PlayerStats playerStats;
    private AudioSource audioSource;
    [SerializeField] AudioClip attackSound;
    [SerializeField] float startTimeBetweenAttack;
    [SerializeField] Rigidbody2D player;

    [SerializeField] Transform attackPos;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask whatIsEnemies;
    [SerializeField] Animator playerAnim; 
	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        playerStats = GetComponent<PlayerStats>();
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
                    audioSource.PlayOneShot(attackSound);
                }
                else
                {
                    playerAnim.Play("PlayerAttack");
                    audioSource.PlayOneShot(attackSound);
                }
                ContactFilter2D contactFilter2DAttack = BuildContactFilter2DForLayer("Attackable");
                Collider2D[] listOfAttackable = new Collider2D[16];
                int numberOfCollisions = Physics2D.OverlapCircle(attackPos.position, attackRange, contactFilter2DAttack, listOfAttackable);
                if(numberOfCollisions > 0)
                {
                    for(int cpt = 0; cpt < numberOfCollisions; cpt++)
                    {
                        listOfAttackable[cpt].transform.gameObject.GetComponent<Attackable>().Attacked(playerStats.attack);
                    }
                }

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

    private ContactFilter2D BuildContactFilter2DForLayer(string LayerName)
    {
        ContactFilter2D contactFilter2DAttack = new ContactFilter2D();
        contactFilter2DAttack.useTriggers = false;
        contactFilter2DAttack.SetLayerMask(Physics2D.GetLayerCollisionMask(LayerMask.NameToLayer(LayerName)));
        contactFilter2DAttack.useLayerMask = true;
        return contactFilter2DAttack;
    }

    public void Attacked(int damage)
    {
        playerStats.health -= damage;
        if(playerStats.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
