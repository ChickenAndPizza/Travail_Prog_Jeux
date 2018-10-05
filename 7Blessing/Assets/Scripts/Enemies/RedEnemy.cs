using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class RedEnemy : MonoBehaviour {

    [SerializeField] Vector2 movementVector = new Vector2(10f, 10f);
    [SerializeField] float period = 2f;

    [Range(0, 1)]
    [SerializeField]
    float movementFactor;
    Vector2 startingPos;


    void Start()
    {
        startingPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*Damagable damagable = collision.gameObject.GetComponent<Damagable>();
        if (damagable != null)
        {
            damagable.DealDamage(bulletDamage);
        }*/

        /*SI JOUEUR COLLIDER : */
        /*if (collision.gameObject.tag == "Player")
        {
            Invoke("die", DestroyFireBallAfterCollisionTime);
        }*/
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
}
