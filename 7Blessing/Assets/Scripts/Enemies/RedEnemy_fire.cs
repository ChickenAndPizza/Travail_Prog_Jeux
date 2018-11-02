using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy_fire : MonoBehaviour {

    [SerializeField] GameObject FireBall;
    [SerializeField] GameObject FireBallEmiter;
    [SerializeField] float fireRate = 1;

    private float timerLastFired = 0;
    void Start()
    {

    }


    void Update()
    {
        timerLastFired += Time.deltaTime;
        if (timerLastFired > fireRate)
        {
            Instantiate(FireBall, FireBallEmiter.transform.position, FireBallEmiter.transform.rotation);
            timerLastFired = 0;
        }

    }
}
