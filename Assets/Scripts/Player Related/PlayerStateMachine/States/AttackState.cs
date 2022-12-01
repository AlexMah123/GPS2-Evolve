using System.Collections;
using UnityEngine;

public class AttackState : PlayerStateMachine
{
    public AttackState(PlayerController system) : base(system) { }

    //No Movement Here

    public override IEnumerator ActionFinished()
    {
        _system.attacking = false;
        _system.animator.SetBool("NormalAttack", false);
        _system.SetState(new NormalState(_system));
        yield break;
    }
}
