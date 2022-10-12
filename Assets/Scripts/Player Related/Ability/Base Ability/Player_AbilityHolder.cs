using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AbilityHolder : MonoBehaviour
{
    //created by Alex

    public Player_BaseAbility skill1;
    public Player_BaseAbility skill2;
    public Player_BaseAbility skill3;

    float tempCooldownTime1;
    float tempActiveTime1;
    float tempCooldownTime2;
    float tempActiveTime2;
    float tempCooldownTime3;
    float tempActiveTime3;

    Player playerInput;

    private void Awake()
    {
        playerInput = new();
    }

    private void Update()
    {
        CheckAbilityStates(skill1);
        CheckAbilityStates(skill2);
        CheckAbilityStates(skill3);
    }

    #region AbilityChecks
    void CheckAbilityStates(Player_BaseAbility skill)
    {
        if(skill == skill1)
        {
            switch (skill.state)
            {
                case Player_BaseAbility.AbilityState.ready:
                    if (playerInput.PlayerMain.Skill1.triggered)
                    {
                        ActivateSkill(skill);
                        tempActiveTime1 = skill.activeTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.active:
                    if(tempActiveTime1 > 0)
                    {
                        tempActiveTime1 -= Time.deltaTime;
                    }
                    else
                    {
                        skill.state = Player_BaseAbility.AbilityState.cooldown;
                        tempCooldownTime1 = skill.cooldownTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.cooldown:
                    if (tempCooldownTime1 > 0)
                    {
                        tempCooldownTime1 -= Time.deltaTime;
                    }
                    else
                    {
                        skill.state = Player_BaseAbility.AbilityState.ready;
                    }
                    break;
            }
        }
        else if (skill == skill2)
        {
            switch (skill.state)
            {
                case Player_BaseAbility.AbilityState.ready:
                    if (playerInput.PlayerMain.Skill2.triggered)
                    {
                        ActivateSkill(skill);
                        tempActiveTime2 = skill.activeTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.active:
                    if (tempActiveTime2 > 0)
                    {
                        tempActiveTime1 -= Time.deltaTime;
                    }
                    else
                    {
                        skill.state = Player_BaseAbility.AbilityState.cooldown;
                        tempCooldownTime2 = skill.cooldownTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.cooldown:
                    if (tempCooldownTime2 > 0)
                    {
                        tempCooldownTime2 -= Time.deltaTime;
                    }
                    else
                    {
                        skill.state = Player_BaseAbility.AbilityState.ready;
                    }
                    break;
            }
        }
        else if(skill == skill3)
        {
            switch (skill.state)
            {
                case Player_BaseAbility.AbilityState.ready:
                    if (playerInput.PlayerMain.Skill3.triggered)
                    {
                        ActivateSkill(skill);
                        tempActiveTime3 = skill.activeTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.active:
                    if (tempActiveTime3 > 0)
                    {
                        tempActiveTime3 -= Time.deltaTime;
                    }
                    else
                    {
                        skill.state = Player_BaseAbility.AbilityState.cooldown;
                        tempCooldownTime3 = skill.cooldownTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.cooldown:
                    if (tempCooldownTime3 > 0)
                    {
                        tempCooldownTime3 -= Time.deltaTime;
                    }
                    else
                    {
                        skill.state = Player_BaseAbility.AbilityState.ready;
                    }
                    break;
            }
        }
    }

    void ActivateSkill(Player_BaseAbility skill)
    {
        Debug.Log(skill.name);
        skill.Activate(gameObject);
        skill.state = Player_BaseAbility.AbilityState.active;
    }

    #endregion
}
