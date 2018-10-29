using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy_fireball : MonoBehaviour//, Attackable
{
    [SerializeField] float DestroyFireBallAfterCollisionTime;
    [SerializeField] float maxLifeTime = 5;
    [SerializeField] float fireBallForce = 4;
    [SerializeField] int fireBallDamage = 20;

    void Start()
    {
        /*rigidBody = GetComponent<Rigidbody>();
        Vector3 ajustedMovement = transform.TransformDirection(Vector3.forward);
        rigidBody.AddForce(ajustedMovement * FireBallForce);*/
        Invoke("DestroyFireBall", maxLifeTime);
    }

    private void Update()
    {
        transform.position += transform.right * -fireBallForce * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Attackable attackable = collision.gameObject.GetComponent<Attackable>();
        if (attackable != null)
        {
            attackable.DealDamage(fireBallDamage);
        }*/

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground" || collision.gameObject.tag != "Enemy")
        {
            Invoke("DestroyFireBall", DestroyFireBallAfterCollisionTime);
        }
    }

    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }

}
