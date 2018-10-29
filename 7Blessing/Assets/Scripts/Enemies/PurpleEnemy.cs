using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : Enemies//, Attackable
{

    [SerializeField] Vector2 movementVector = new Vector2(2f, 10f);
    [SerializeField] float period = 10f;

    [Range(0, 1)]
    [SerializeField]
    float movementFactor;
    Vector2 startingPos;
    Vector2 offset;

    private Animator mAnimator;
    private bool facingLeft = false;
    private float moveX = 0;

    void Start () {
        startingPos = transform.position;
        offset = transform.position;
        mAnimator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*Attackable attackable = collision.gameObject.GetComponent<Attackable>();
        if (attackable != null)
        {
            attackable.DealDamage(attack);
        }*/



        /*SI JOUEUR COLLIDER : */
        /*if (collision.gameObject.tag == "Player")
        {
            Invoke("die", DestroyFireBallAfterCollisionTime);
        }*/
    }

    void Update ()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        float wave = (movementVector.x * rawSinWave / 120);
        startingPos.x = startingPos.x + wave;
        transform.position = startingPos;

        moveX = transform.position.x;
        if (wave > 0.0f && !facingLeft)
        {
            FlipMonster();
        }
        else if (wave < 0.0f && facingLeft)
        {
            FlipMonster();
        }
    }

    void FlipMonster()
    {
        facingLeft = !facingLeft;
        Vector2 localscale = gameObject.transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }
}
