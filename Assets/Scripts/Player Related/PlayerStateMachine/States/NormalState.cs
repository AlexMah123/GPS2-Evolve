using System.Collections;
using UnityEngine;

//created by Shane, editted by Alex
public class NormalState : PlayerStateMachine
{
    public NormalState(PlayerController system) : base(system) { }

    public override IEnumerator Start()
    {
        yield break;
    }
    public override IEnumerator Movement(Vector3 move)
    {

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
        _system.playerVelocity.y += Mathf.Abs(_system.jumpHeight * _system.gravityValue/_system.jumpForce);
        _system.SetState(new JumpState(_system));
        yield break;
    }

    public override IEnumerator Devour()
    {
        _system.animator.SetBool("Devour", true);
        _system.devouring = true;
        _system.lookAt = true;

        //checks and runs the coroutine on the enemybody to be devoured
        if(_system.deathbodyList[0] != null)
        {
            GameObject enemy = _system.deathbodyList[0];
            _system.StartCoroutine(enemy.GetComponent<EnemyDevour>().Devouring(enemy));
        }

        _system.SetState(new DevourState(_system));
        yield break;
    }

    public override IEnumerator SkillState(Player_BaseAbility skill)
    {
        _system.skillActive = true;

        switch (skill.name)
        {
            //Skill Code here
            case "Bite":
                _system.biteActive = true;
                _system.SetState(new SkillState(_system));
                yield break;

            case "Roar":
                _system.roarActive = true;
                _system.SetState(new SkillState(_system));
                yield break;

            case "Dash":
                _system.dashActive = true;
                _system.SetState(new SkillState(_system));
                yield break;

            case "Smash":
                _system.smashActive = true;
                _system.SetState(new SkillState(_system));
                yield break;

            case "Whip":
                _system.whipActive = true;
                _system.SetState(new SkillState(_system));
                yield break;

            case "Leap Smash":
                _system.leapsmashActive = true;
                _system.SetState(new SkillState(_system));
                yield break;

            default:
                Debug.Log("Something went wrong, you shouldn't be seeing this");
                yield break;
        }


    }

}
