using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BossController boss = null;
    [SerializeField] private bool phaseTwo = false;

    private void Update()
    {
        if(boss.Health >= (boss.Health * 0.5f))
        {
            phaseTwo = true;
            boss.ChangeBehavior();
        }
    }
}
