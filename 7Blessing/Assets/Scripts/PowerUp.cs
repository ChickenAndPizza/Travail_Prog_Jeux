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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name =="Player")
        {
            if(this.name == "GreenPotion")
            {
                StartCoroutine(PickUpGreenPotion(other));
            }
            else if(this.name =="RedPotion")
            {
                PickUpRedPotion(other);
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
        yield return new WaitForSeconds(duration);
        stats.playerSpeed = normalSpeed;
    }

    void PickUpRedPotion(Collider2D player)
    {
        HealthBar healthBar = player.GetComponent<HealthBar>();
        healthBar.HealDamage(healingPower);
        Destroy(gameObject);
    }

    IEnumerator PickUpYellowFeather(Collider2D player)
    {
        Player_Move_Prot stats = player.GetComponent<Player_Move_Prot>();
        stats.playerJumpPower = superJumpPower;
        yield return new WaitForSeconds(duration);
        stats.playerJumpPower = normalJumpPower;
    }
}
