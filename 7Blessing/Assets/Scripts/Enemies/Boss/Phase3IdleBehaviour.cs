using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase3IdleBehaviour : StateMachineBehaviour {
    
    private Transform IdlePosition;
    public float speed;

    public float timer;
    public float minTime;
    public float maxTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        IdlePosition = FindObjectOfType<IdlePhase3Position>().idlePhase3Position;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("Phase3Attack");
        }
        else
        {
            timer -= Time.deltaTime;
        }
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, IdlePosition.position, speed * Time.deltaTime);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
