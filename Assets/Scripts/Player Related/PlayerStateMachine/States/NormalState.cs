using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : PlayerStateMachine
{
    public NormalState(PlayerController system) : base(system) { }

    public override IEnumerator Start()
    {
        yield break;
    }
    public override IEnumerator Movement()
    {
        //Player Movement should be moved here when done
        yield break;
    }

    public override IEnumerator Melee()
    {
        _system.attacking = true;
        _system.SetState(new AttackState(_system));
        yield break;
    }
}
