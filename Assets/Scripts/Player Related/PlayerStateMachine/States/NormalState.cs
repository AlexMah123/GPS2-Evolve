using System.Collections;
using UnityEngine;

public class NormalState : PlayerStateMachine
{
    public NormalState(PlayerController system) : base(system) { }

    public override IEnumerator Start()
    {
        yield break;
    }
    public override IEnumerator Movement(Vector3 move)
    {
        //Player Movement should be moved here when done
        _system.animator.SetFloat("Running", move != Vector3.zero ? 1 : 0);
        move.y = 0;
        _system.controller.Move(_system.playerSpeed * Time.deltaTime * move);
        yield break;
    }

    public override IEnumerator Melee()
    {
        _system.attacking = true;
        _system.animator.SetBool("NormalAttack", true);
        _system.SetState(new AttackState(_system));
        yield break;
    }

    public override IEnumerator Jump()
    {
        _system.playerVelocity.y += Mathf.Sqrt(_system.jumpHeight * -3.0f * _system.gravityValue);
        _system.groundedPlayer = false;
        _system.SetState(new JumpState(_system));
        yield break;
    }
}
