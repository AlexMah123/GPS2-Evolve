using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateMachine
{
    //Shane, All States also by Shane (unless stated otherwise)
    protected readonly PlayerController _system;

    public PlayerStateMachine(PlayerController sys)
    {
        _system = sys;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Jump()
    {
        yield break;
    }

    public virtual IEnumerator Movement(Vector3 move)
    {
        yield break;
    }

    public virtual IEnumerator Melee()
    {
        yield break;
    }

    public virtual IEnumerator ActionFinished()
    {
        yield break;
    }

    public virtual IEnumerator JumpFinished()
    {
        yield break;
    }
    public virtual IEnumerator Devour()
    {
        yield break;
    }

    public virtual IEnumerator DevourFinished()
    {
        yield break;
    }
    public virtual IEnumerator Death()
    {
        _system.SetState(new DeathState(_system));
        yield break;
    }

    public virtual IEnumerator SkillState(Player_BaseAbility skill)
    {
        yield break;
    }

    public virtual IEnumerator SkillFinished()
    {
        yield break;
    }
}
