using QInventory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

[DisallowMultipleComponent]
public class RedEnemy : Enemies, Attackable
{
    private AudioSource audioSource;
    [SerializeField] AudioClip dammageSound;
    [SerializeField] Vector2 movementVector = new Vector2(10f, 10f);
    [SerializeField] float period = 2f;
    [SerializeField] ParticleSystem bloodEffect;

    [Range(0, 1)]
    [SerializeField]
    float movementFactor;
    Vector2 startingPos;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startingPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Attackable attackable = collision.gameObject.GetComponent<Attackable>();
        
        if (attackable != null)
        {
            attackable.Attacked(attack);
        }
    }

    void Update()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        Vector2 offset = movementVector * rawSinWave / 120;
        transform.position = startingPos + offset;

    }

    private void DestroyMonster()
    {
        Destroy(transform.parent.gameObject);
    }

    public void Attacked(int damage)
    {
        audioSource.PlayOneShot(dammageSound);
        Instantiate(bloodEffect, gameObject.transform);
        health -= damage;
        if(health <= 0)
        {
            GetComponent<DropItem>().DropItems();
            StartCoroutine(Death());
            
        }
    }

    IEnumerator Death()
    {
        this.enabled = false;
        yield return new WaitForSeconds(0.3f);
        DestroyMonster();
    }

    public void Heal(int healPower)
    {
        health += healPower;
    }
}
