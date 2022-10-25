using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_AbilityHolder : MonoBehaviour
{
    //created by Alex

    public static Player_AbilityHolder Instance;

    public Player_BaseAbility skill1;
    public Player_BaseAbility skill2;
    public Player_BaseAbility skill3;

    [SerializeField] TextMeshProUGUI skill1TMP;
    [SerializeField] TextMeshProUGUI skill2TMP;
    [SerializeField] TextMeshProUGUI skill3TMP;

    [SerializeField] Slider activeTime;

    float tempCooldownTime1;
    float tempActiveTime1;
    float tempCooldownTime2;
    float tempActiveTime2;
    float tempCooldownTime3;
    float tempActiveTime3;

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
                    skill1TMP.text = skill.name;
                    if (PlayerController.Instance.playerInput.PlayerMain.Skill1.triggered)
                    {
                        ActivateSkill(skill);
                        tempActiveTime1 = skill.activeTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.active:
                    skill1TMP.text = "Active";
                    if (tempActiveTime1 > 0)
                    {
                        tempActiveTime1 -= Time.deltaTime;
                        //activeTime.value = tempActiveTime1 / skill.activeTime;
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
                        skill1TMP.text = Math.Round(tempCooldownTime1, 1).ToString();
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
                    skill2TMP.text = skill.name;
                    if (PlayerController.Instance.playerInput.PlayerMain.Skill2.triggered)
                    {
                        ActivateSkill(skill);
                        tempActiveTime2 = skill.activeTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.active:
                    skill2TMP.text = "Active";
                    if (tempActiveTime2 > 0)
                    {
                        tempActiveTime2 -= Time.deltaTime;
                        //activeTime.value = tempActiveTime2 / skill.activeTime;
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
                        skill2TMP.text = Math.Round(tempCooldownTime2, 1).ToString();
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
                    skill3TMP.text = skill.name;
                    if (PlayerController.Instance.playerInput.PlayerMain.Skill3.triggered)
                    {
                        ActivateSkill(skill);
                        tempActiveTime3 = skill.activeTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.active:
                    skill3TMP.text = "Active";
                    if (tempActiveTime3 > 0)
                    {
                        tempActiveTime3 -= Time.deltaTime;
                        //activeTime.value = tempActiveTime3 / skill.activeTime;
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
                        skill3TMP.text = Math.Round(tempCooldownTime3, 1).ToString();
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
        //Debug.Log(skill.name);
        skill.Activate(gameObject);
        skill.state = Player_BaseAbility.AbilityState.active;
    }

    #endregion
}
