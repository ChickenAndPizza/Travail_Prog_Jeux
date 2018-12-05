using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPhase3 : StateMachineBehaviour {
    Player_Move_Prot player;
    public float speed;
    private Transform AttackPosition;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<Player_Move_Prot>();
        AttackPosition = FindObjectOfType<AttackPosition>().attackPosition;
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, AttackPosition.position, speed * Time.deltaTime);
        player.DisableControl();
    }
}
