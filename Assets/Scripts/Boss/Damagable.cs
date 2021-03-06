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

    private void Start()
    {
        bossController = GetComponentInParent<BossController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Weapon" && bossController.Player.IsAttacking == true)
        {
            // stun timer check
            if (bossController.StunTimer.TimerOver == true)
            {
                bossController.HitCounter = 0;
                bossController.StunTimer.StartTimer(5);
            }
            else
            {
                // add hitpoints for stun
                if (bossController.Player.GetCurrentWeaponObject().GetCurrentAttackType() == WeaponAttackTypeEnum.HEAVY || bossController.Player.ComboSuccess() == true || bossController.Player.GetCurrentWeaponObject().GetWeaponWeight() == 15)
                {
                    bossController.HitCounter += Random.Range(2, 5);
                }
                else if (bossController.Player.GetCurrentWeaponObject().GetWeaponWeight() == 12)
                {
                    bossController.HitCounter += 2;
                }
                else
                {
                    bossController.HitCounter += 1;
                }
            }

            // check stun
            if (bossController.HitCounter >= bossController.StunCount && bossController.StunTimer.TimerOver == false)
            {
                bossController.IsStunned = true;
                bossController.IsStunnedTimer.StartTimer(4);
            }

            // get damage
            float damage = bossController.Player.GetCurrentWeaponObject().GetDamage();

            bossController.Animator.ResetTrigger("Walk");

            // hit animations
            if (bossController.IsStunned == false)
            {
                if (bossController.IsFlying == true)
                {
                    if(bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Fly Got Hit"))
                    {
                        bossController.Animator.SetTrigger("Hit 3");
                    }
                }
                else if (position == PositionEnum.LEFT)
                {
                    if (bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Got Hit 2"))
                    {
                        bossController.Animator.SetTrigger("Hit 2");
                    }
                }
                else if (position == PositionEnum.RIGHT)
                {
                    if (bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Got Hit 1"))
                    {
                        bossController.Animator.SetTrigger("Hit 1");
                    }
                }
                else
                {
                    int random = Random.Range(0, 100);
                    if (random % 2 == 0)
                    {
                        bossController.Animator.SetTrigger("Hit 1");
                    }
                    else
                    {
                        bossController.Animator.SetTrigger("Hit 2");
                    }
                }
            }

            // take damage
            bossController.TakeDamage(damage + crit);
        }
    }
        
}
