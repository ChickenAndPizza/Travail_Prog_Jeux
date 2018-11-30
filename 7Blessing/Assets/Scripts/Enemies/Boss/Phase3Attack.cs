using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase3Attack : StateMachineBehaviour {

    public float fireRate = 1;
    private BossShooting boss;

    private float timerLastFired = 0;

    private Transform AttackPosition;
    public float speed;

    public float timer;
    public float minTime;
    public float maxTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        AttackPosition = FindObjectOfType<AttackPosition>().attackPosition;
        boss = FindObjectOfType<BossShooting>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("TriggerPhase3Idle");
        }
        else
        {
            timer -= Time.deltaTime;
        }
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, AttackPosition.position, speed * Time.deltaTime);
        if (Vector2.Distance(animator.transform.position, AttackPosition.position) < 0.2f)
        {
            timerLastFired += Time.deltaTime;
            if (timerLastFired > fireRate)
            {
                boss.Shoot();
                timerLastFired = 0;
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
