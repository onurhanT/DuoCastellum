﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MinionBehaviour : StateMachineBehaviour
{
    private EnemyController controller;
    private Animator player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.gameObject.GetComponent<EnemyController>();
        player = animator.gameObject.GetComponent<Animator>();
        animator.SetTrigger("idle");

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        
        if (controller.StayAtIdle())
        {
            player.SetBool("is_dead", true);
            player.SetBool("run_con", true);
            player.SetBool("on_exit", true);
            player.SetBool("attack_con", true);
        }
        if (!controller.StayAtIdle())
        {
            player.SetTrigger("run");
            player.SetBool("startIdle", false);
            player.SetBool("run_con", false);
            player.SetBool("run_con2", false);
        }
        if (!controller.IsEnemyDied())
        {
            player.SetBool("is_enemy_die", true);

        }

        if (controller.IsEnemyDied())
        {
            if (stateInfo.IsName("Run"))
            {
                controller.SetTarget();
            }
            
        }
        


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.SetTarget();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (!controller.IsAtDeathState())
        {
            player.SetBool("is_dead", true);
            player.ApplyBuiltinRootMotion();
            if (controller.CanAttack())
            {
                //animator.applyRootMotion = false;
                player.SetBool("on_exit", false);
                player.SetBool("run_con", true);
                player.SetBool("run_con2", false);
                player.SetBool("is_enemy_die", true);
                player.SetBool("attack_con", false);
                player.SetBool("can_exit", true);
                player.SetTrigger("attack");
                if (stateInfo.IsName("wait_for_attack"))
                {
                    if (Time.frameCount % 30 == 0)
                    {
                        controller.Attack();
                    }
                }
                if (controller.IsEnemyDied())
                {
                    player.SetBool("is_dead", true);
                    player.SetBool("attack_con", true);
                    player.SetBool("is_enemy_die", false);
                    player.SetBool("on_exit", true);
                    player.SetBool("can_exit", false);
                    
                }
            }
        }
       
    }


}

// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//
//}

