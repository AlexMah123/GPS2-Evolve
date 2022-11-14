using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : PlayerStateMachine
{
    public SkillState(PlayerController system) : base(system) { }
    public override IEnumerator SkillFinished()
    {
        //Animator Stuff should be here

        //reset all states
        _system.skillActive = false;
        _system.biteActive = false;
        _system.roarActive = false;
        _system.dashActive = false;
        _system.smashActive = false;
        _system.whipActive = false;
        _system.leapsmashActive = false;

        _system.SetState(new NormalState(_system));
        yield break;
    }
}
