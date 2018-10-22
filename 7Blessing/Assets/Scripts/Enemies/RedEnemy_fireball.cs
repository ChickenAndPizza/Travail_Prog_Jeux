using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy_fireball : MonoBehaviour {

    /*Rigidbody rigidBody;*/
    [SerializeField] float DestroyFireBallAfterCollisionTime;
    [SerializeField] float maxLifeTime = 5f;
    [SerializeField] float FireBallForce = 1500;
    [SerializeField] int FireBallDamage = 20;

    void Start()
    {
        /*rigidBody = GetComponent<Rigidbody>();
        Vector3 ajustedMovement = transform.TransformDirection(Vector3.forward);
        rigidBody.AddForce(ajustedMovement * FireBallForce);*/
        Invoke("DestroyFireBall", maxLifeTime);
    }

    private void Update()
    {
        transform.position += transform.right * -FireBallForce * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*Damagable damagable = collision.gameObject.GetComponent<Damagable>();
        if (damagable != null)
        {
            damagable.DealDamage(bulletDamage);
        }*/

        /* SI JOUEUR COLLIDER : */
        print(collision.gameObject.tag);
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            Invoke("DestroyFireBall", DestroyFireBallAfterCollisionTime);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Invoke("DestroyFireBall", DestroyFireBallAfterCollisionTime);
        }
        if (collision.gameObject.tag != "Enemy")
        {
            Invoke("DestroyFireBall", DestroyFireBallAfterCollisionTime);
        }
    }

    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }

}
