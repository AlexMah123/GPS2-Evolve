using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : PlayerStateMachine
{
    public SkillState(PlayerController system) : base(system) { }
    public override IEnumerator SkillFinished()
    {
        //Animator Stuff should be here
        _system.SetState(new NormalState(_system));
        yield break;
    }
}
