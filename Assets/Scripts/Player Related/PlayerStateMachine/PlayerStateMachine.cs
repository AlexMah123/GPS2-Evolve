using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateMachine
{
    //Shane
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

    public virtual IEnumerator Movement()
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
    public virtual IEnumerator Devour()
    {
        yield break;
    }

    public virtual IEnumerator Death()
    {
        yield break;
    }
}
