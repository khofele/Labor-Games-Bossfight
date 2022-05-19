using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("AttackLeft")]
public class AttackLeft : GOAction
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
    }

    public override TaskStatus OnUpdate()
    {
        if(bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack 2_2"))
        {
            bossController.Animator.SetTrigger("Attack 2");
        }
        attackManager.CurrentAttack = attackManager.AttackLeft;
        Debug.Log("Attack Left");
        return TaskStatus.COMPLETED;
    }
}
