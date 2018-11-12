using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {
    [SerializeField] float shurikenLife = 1;
    [SerializeField] float speed = 5;
    [SerializeField] int shurikenDamage = 5;
    [SerializeField] AudioClip hit;
    private AudioSource audioSource;
    private bool goingLeft;
	// Use this for initialization
	void Start () {
        Invoke("DestroyShuriken", shurikenLife);

    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(hit);
    }

    private void DestroyShuriken()
    {
        Destroy(gameObject);
    }
}
