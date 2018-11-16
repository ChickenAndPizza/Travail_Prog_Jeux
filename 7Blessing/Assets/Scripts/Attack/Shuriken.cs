using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {
    [SerializeField] float shurikenLife = 1;
    [SerializeField] float speed = 5;
    [SerializeField] int shurikenDamage = 5;
    public int direction;
	// Use this for initialization
	void Start () {
        Invoke("DestroyShuriken", shurikenLife);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.right * direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {

            Attackable attackable = collision.gameObject.GetComponent<Attackable>();
            if (attackable != null)
            {
                attackable.Attacked(shurikenDamage);
            }

            DestroyShuriken();
        }
    }

    private void DestroyShuriken()
    {
        Destroy(gameObject);
    }
}
