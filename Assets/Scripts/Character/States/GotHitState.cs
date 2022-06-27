using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class GotHitState : BaseState
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //player has currently been hit - animation shall not play twice at a time
            animator.SetBool("alreadyHit", true);

            //sound
            GetAudioPlayer(animator).PlayHit();

            //set all bool parameters of aborted actions to false
            //damage combo is aborted
            animator.SetBool("Attack01R", false);
            animator.SetBool("Attack02R", false);
            animator.SetBool("Attack03R", false);
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("GotHit", false);
            animator.SetBool("alreadyHit", false);
        }
    }

}