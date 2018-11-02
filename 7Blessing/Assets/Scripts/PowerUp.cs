using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private int superSpeed = 7;
    private int normalSpeed = 5;
    private int superJumpPower = 10;
    private int normalJumpPower = 7;
    private float healingPower = 25;
    private float duration = 5f;
    private GameObject pcikUpEffect;
    [SerializeField] AudioClip clip;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name =="Player")
        {
            audioSource.PlayOneShot(clip);
            if(this.tag == "GreenPotion")
            {
                StartCoroutine(PickUpGreenPotion(other));
            }
            else if(this.tag =="RedPotion")
            {
                StartCoroutine(PickUpRedPotion(other));
            }
            else if (this.tag == "YellowFeather")
            {
                StartCoroutine(PickUpYellowFeather(other));
            }
        }
    }

    IEnumerator PickUpGreenPotion(Collider2D player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.speed = superSpeed;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        stats.speed = normalSpeed;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    IEnumerator PickUpRedPotion(Collider2D player)
    {
        HealthBar healthBar = player.GetComponent<HealthBar>();
        healthBar.Heal((int)healingPower);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    IEnumerator PickUpYellowFeather(Collider2D player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.jumpPower = superJumpPower;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        stats.jumpPower = normalJumpPower;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
