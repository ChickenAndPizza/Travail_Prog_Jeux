﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingBehaviour : StateMachineBehaviour {

    private Transform target;
    private GameObject audioSource;
    public AudioClip bossTrack;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GameObject.FindGameObjectWithTag("MusicPlayer");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector2.Distance(animator.transform.position, target.position)< 7)
        {
            Player_Move_Prot player = FindObjectOfType<Player_Move_Prot>();
            player.DisableControl();
            Boss boss = FindObjectOfType<Boss>();
            boss.BossBattleTrack(bossTrack);
            animator.SetTrigger("StartIntro");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
