using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class HeavyAttackState : BaseState
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Heavy Attack");

            //use neededStamina for action
            neededStamina = 60f;
            GetCharController(animator).UseStamina(neededStamina);
            GetCharController(animator).SetRegStamina(false); //no stamina reg during skill
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //player finished attack
            animator.SetBool("HeavyAttack", false);
            GetCharController(animator).SetRegStamina(true); //regenerate stamina again
        }
    }

}