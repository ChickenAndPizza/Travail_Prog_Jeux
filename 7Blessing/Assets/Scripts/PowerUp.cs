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
            if(this.name == "GreenPotion")
            {
                StartCoroutine(PickUpGreenPotion(other));
            }
            else if(this.name =="RedPotion")
            {
                StartCoroutine(PickUpRedPotion(other));
            }
            else if (this.name == "YellowFeather")
            {
                StartCoroutine(PickUpYellowFeather(other));
            }
        }
    }

    IEnumerator PickUpGreenPotion(Collider2D player)
    {
        Player_Move_Prot stats = player.GetComponent<Player_Move_Prot>();
        stats.playerSpeed = superSpeed;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        stats.playerSpeed = normalSpeed;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    IEnumerator PickUpRedPotion(Collider2D player)
    {
        HealthBar healthBar = player.GetComponent<HealthBar>();
        healthBar.HealDamage(healingPower);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    IEnumerator PickUpYellowFeather(Collider2D player)
    {
        Player_Move_Prot stats = player.GetComponent<Player_Move_Prot>();
        stats.playerJumpPower = superJumpPower;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        stats.playerJumpPower = normalJumpPower;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
