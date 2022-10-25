using System.Collections;
using UnityEngine;

public class JumpState : PlayerStateMachine
{
    public JumpState(PlayerController system) : base(system) { }

    //No Movement Here(?)
    public override IEnumerator Movement(Vector3 move)
    {
        _system.animator.SetFloat("Running", move != Vector3.zero ? 1 : 0);
        move.y = 0;
        _system.controller.Move(_system.playerSpeed * Time.deltaTime * move);
        yield break;
    }

    public override IEnumerator JumpFinished()
    {
        //Animator Stuff should be here

        _system.animator.SetBool("Jumping", false);
        _system.SetState(new NormalState(_system));
        yield break;
    }
}
