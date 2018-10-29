using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy_fireball : MonoBehaviour
{
    [SerializeField] float DestroyFireBallAfterCollisionTime;
    [SerializeField] float maxLifeTime = 5;
    [SerializeField] float fireBallForce = 4;
    [SerializeField] int fireBallDamage = 20;

    void Start()
    {
        Invoke("DestroyFireBall", maxLifeTime);
    }

    private void Update()
    {
        transform.position += transform.right * -fireBallForce * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {

            Attackable attackable = collision.gameObject.GetComponent<Attackable>();
            if (attackable != null)
            {
                attackable.Attacked(fireBallDamage);
            }
        

            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
            {
                Invoke("DestroyFireBall", DestroyFireBallAfterCollisionTime);
            }
        }
    }

    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }
}
