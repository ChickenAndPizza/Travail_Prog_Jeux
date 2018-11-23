using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1Behaviour : StateMachineBehaviour {

    public float speed;
    private Transform playerPos;

    public float timer;
    public float minTime;
    public float maxTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        timer = Random.Range(minTime, maxTime);
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("Floating");
        }
        else
        {
            timer -= Time.deltaTime;
        }
        Vector2 target = new Vector2(playerPos.position.x, playerPos.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    
}
