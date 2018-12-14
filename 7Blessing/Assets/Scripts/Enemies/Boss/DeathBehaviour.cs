using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour : StateMachineBehaviour {
    Boss boss;

    public float timer;
    public float minTime;
    public float maxTime;
    GameObject angel;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = FindObjectOfType<Boss>();
        timer = Random.Range(minTime, maxTime);
        angel = GameObject.FindGameObjectWithTag("EndingScene");

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.PlayDeathSound();
        Color tmp = angel.GetComponent<SpriteRenderer>().color;
        tmp.a = 1;
        angel.GetComponent<SpriteRenderer>().color = tmp;
        angel.GetComponent<BoxCollider2D>().enabled = true;
        if (timer <= 0)
        {
            boss.KillBoss();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
