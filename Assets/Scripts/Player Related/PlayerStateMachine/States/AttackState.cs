using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerStateMachine
{
    public AttackState(PlayerController system) : base(system) { }

    public override IEnumerator Movement()
    {
        //Player Movement should be moved here when done
        yield break;
    }

    public override IEnumerator Melee()
    {
        yield break;
    }
}
