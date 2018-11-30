using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBehaviour : StateMachineBehaviour {

    private Transform[] PatrolPoints;
    public float speed;
    private float waitTime;
    public float startWaitTime;
    private int randomSpot;

    public float timer;
    public float minTime;
    public float maxTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        waitTime = startWaitTime;
        PatrolPoints = FindObjectOfType<PatrolPoints>().patrolPoints;

        randomSpot = Random.Range(0, PatrolPoints.Length);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("Phase1");
        }
        else
        {
            timer -= Time.deltaTime;
        }
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, PatrolPoints[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(animator.transform.position, PatrolPoints[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, PatrolPoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
