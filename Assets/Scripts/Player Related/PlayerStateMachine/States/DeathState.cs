using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathState : PlayerStateMachine
{
    public DeathState(PlayerController system) : base(system) { }

    //There shouldnt be any code here unless theres something that the player can only do when dead
    //Just a dead end for the FSM to go to
    public override IEnumerator Start()
    {
        _system.animator.SetBool("Death", true);
        yield break;
    }
}
