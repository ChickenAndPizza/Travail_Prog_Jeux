using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectiles : MonoBehaviour {
    public float speed;
    private GameObject player;
    private Transform target;
    
    [SerializeField] int mageBulletDamage = 5;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
	}
	
	void Update () {
        transform.position += transform.right * speed * Time.deltaTime ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Boss" && collision.gameObject.tag != "BossHead" && collision.gameObject.tag != "Protection" && collision.gameObject.tag != "Untagged")
        {
            Attackable attackable = collision.gameObject.GetComponent<Attackable>();
            if (attackable != null)
            {
                attackable.Attacked(mageBulletDamage);
            }


            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
            {
                Destroy(gameObject);
            }
        }
    }
}
