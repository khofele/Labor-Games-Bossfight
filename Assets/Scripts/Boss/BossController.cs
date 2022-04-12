using BBUnity;
using Pada1.BBCore.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float health = 1000;
    [SerializeField] private InternalBrickAsset behaviorPhaseTwo = null;

    public float Health
    {
        get => health;
        set
        {
            health = value;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void ChangeBehavior()
    {
        if(behaviorPhaseTwo != null)
        {
            gameObject.GetComponent<BehaviorExecutor>().behavior = behaviorPhaseTwo;
        }
    }
}
