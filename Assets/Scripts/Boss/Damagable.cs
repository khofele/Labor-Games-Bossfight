using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionEnum
{
    FRONT, LEFT, RIGHT, BACK
}

public class Damagable : MonoBehaviour
{
    [SerializeField] private float crit = 0;
    [SerializeField] private PositionEnum position;
    private BossController bossController = null;

    private void OnCollisionEnter(Collision collision)
    {
        if(bossController.StunTimer.TimerOver == true)
        {
            bossController.HitCounter = 0;
            bossController.StunTimer.StartTimer(10);    // TODO: Balancing
        }
        else
        {
            bossController.HitCounter++;
        }

        if(bossController.HitCounter >= bossController.StunCount && bossController.IsStunnedTimer.TimerOver == false)
        {
            bossController.IsStunned = true;
            bossController.IsStunnedTimer.StartTimer(5);    // TODO: Balancing
        }

        // TODO: GetSchaden von Spielerwaffe
        
        if(bossController.IsStunned == false)
        {
            if(bossController.IsFlying == true)
            {
                bossController.Animator.SetTrigger("Hit 3");
            }
            else if(position == PositionEnum.LEFT)
            {
                bossController.Animator.SetTrigger("Hit 2");
            }
            else if (position == PositionEnum.RIGHT)
            {
                bossController.Animator.SetTrigger("Hit 1");
            }
            else
            {
                int random = Random.Range(0, 100);
                if(random%2 == 0)
                {
                    bossController.Animator.SetTrigger(""); // TODO: Animations Task
                }
                else
                {
                    bossController.Animator.SetTrigger(""); // TODO: Animations Task
                }
            }
        }


        //bossController.TakeDamage(waffenSchaden + crit);

    }
}