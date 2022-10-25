using System.Collections;

public class DevourState : PlayerStateMachine
{
    public DevourState(PlayerController system) : base(system) { }

    //No Movement Here

    public override IEnumerator DevourFinished()
    {
        //Animator Stuff should be here
        _system.animator.SetBool("Devour", false);
        _system.SetState(new NormalState(_system));
        yield break;
    }
}
