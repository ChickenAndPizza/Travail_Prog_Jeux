using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2Behaviour : StateMachineBehaviour {
    
    public float fireRate = 1;
    private BossShooting boss;

    private float timerLastFired = 0;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = FindObjectOfType<BossShooting>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timerLastFired += Time.deltaTime;
        if (timerLastFired > fireRate)
        {
            boss.Shoot();
            timerLastFired = 0;
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
