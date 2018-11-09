using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShuriken : MonoBehaviour {
    [SerializeField] float timeOut = 2;
    [SerializeField] GameObject shuriken;
    [SerializeField] GameObject emmiter;
    private float timeLastFired = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLastFired += Time.deltaTime;
		if(Input.GetAxis("Fire3") != 0 && timeLastFired > timeOut)
        {
            Instantiate(shuriken, emmiter.transform.position, emmiter.transform.rotation);
            timeLastFired = 0;
        }
	}
}
