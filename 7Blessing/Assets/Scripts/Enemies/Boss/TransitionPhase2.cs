using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPhase2 : StateMachineBehaviour {
    Player_Move_Prot player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<Player_Move_Prot>();
        player.DisableControl();
    }
}
