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

    [Header("Abilities")]
    [NonReorderable] public List<Player_BaseAbility> totalSkillList = new();
    public List<Player_BaseAbility> displaySkillList = new();
    public List<Player_BaseAbility> selectedSkillList = new();

    [Header("Ability Button")]
    [HideInInspector] public Player_BaseAbility skill1;
    [HideInInspector] public Player_BaseAbility skill2;
    [HideInInspector] public Player_BaseAbility skill3;

    [SerializeField] Button skill1Button;
    [SerializeField] Button skill2Button;
    [SerializeField] Button skill3Button;
    [SerializeField] TextMeshProUGUI skill1TMP;
    [SerializeField] TextMeshProUGUI skill2TMP;
    [SerializeField] TextMeshProUGUI skill3TMP;
    [SerializeField] Slider activeTime;

    [Header("Ability Selection")]
    [SerializeField] GameObject skill1Obj;
    [SerializeField] Image skill1Logo;
    [SerializeField] TextMeshProUGUI skill1Desc;
    [SerializeField] TextMeshProUGUI skill1Name;

    [SerializeField] GameObject skill2Obj;
    [SerializeField] Image skill2Logo;
    [SerializeField] TextMeshProUGUI skill2Desc;
    [SerializeField] TextMeshProUGUI skill2Name;

    [SerializeField] GameObject skill3Obj;
    [SerializeField] Image skill3Logo;
    [SerializeField] TextMeshProUGUI skill3Desc;
    [SerializeField] TextMeshProUGUI skill3Name;

    [Header("Player Related")]
    [SerializeField] Animator anim;
    [SerializeField] GameObject player;
    [SerializeField] float Blend;

    float tempCooldownTime1;
    float tempActiveTime1;
    float tempCooldownTime2;
    float tempActiveTime2;
    float tempCooldownTime3;
    float tempActiveTime3;


    private void Start()
    {
        SelectingAbility();
    }


    private void Update()
    {
        for (int i = 0; i < selectedSkillList.Count; i++)
        {
            if (selectedSkillList[i] != null)
            {
                CheckAbilityStates(selectedSkillList[i]);
                UpdateAbilityChosen();
            }
        }

        
    }

    #region AbilityChecks
    public void CheckAbilityStates(Player_BaseAbility skill)
    {
        if(skill == skill1)
        {
            switch (skill.state)
            {
                case Player_BaseAbility.AbilityState.ready:
                    skill1Button.interactable = true;
                    skill1TMP.text = skill.name;
                    if (PlayerController.Instance.playerInput.PlayerMain.Skill1.triggered)
                    {
                        ActivateSkill(skill);
                        anim.SetTrigger(skill.name);
                        tempActiveTime1 = skill.activeTime;
                        Blend = 0;
                    }
                    break;

                case Player_BaseAbility.AbilityState.active:
                    skill1TMP.text = "Active";
                    if (tempActiveTime1 > 0)
                    {
                        tempActiveTime1 -= Time.deltaTime;
                        Blend += Time.deltaTime;
                        skill1Button.interactable = false;
                        anim.SetFloat("Blend", Blend) ;
                        //activeTime.value = tempActiveTime1 / skill.activeTime;
                    }
                    else
                    {
 

                        StartCoroutine(PlayerController.Instance.currentState.SkillFinished());
                        skill.state = Player_BaseAbility.AbilityState.cooldown;
                        tempCooldownTime1 = skill.cooldownTime;

                    }
                    break;

                case Player_BaseAbility.AbilityState.cooldown:
                    if (tempCooldownTime1 > 0)
                    {
                        Blend -= Time.deltaTime;
                        anim.SetFloat("Blend", Blend);
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
                    skill2Button.interactable = true;
                    skill2TMP.text = skill.name;
                    if (PlayerController.Instance.playerInput.PlayerMain.Skill2.triggered)
                    {
                        ActivateSkill(skill);
                        anim.SetTrigger(skill.name);
                        tempActiveTime2 = skill.activeTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.active:
                    skill2TMP.text = "Active";
                    if (tempActiveTime2 > 0)
                    {
                        tempActiveTime2 -= Time.deltaTime;
                        skill2Button.interactable = false;
                        anim.SetFloat("Blend", skill.activeTime - tempActiveTime2);

                        //activeTime.value = tempActiveTime2 / skill.activeTime;
                    }
                    else
                    {
                        StartCoroutine(PlayerController.Instance.currentState.SkillFinished());
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
                    skill3Button.interactable = true;
                    skill3TMP.text = skill.name;
                    if (PlayerController.Instance.playerInput.PlayerMain.Skill3.triggered)
                    {
                        ActivateSkill(skill);
                        anim.SetTrigger(skill.name);
                        tempActiveTime3 = skill.activeTime;
                    }
                    break;

                case Player_BaseAbility.AbilityState.active:
                    skill3TMP.text = "Active";
                    if (tempActiveTime3 > 0)
                    {
                        tempActiveTime3 -= Time.deltaTime;
                        skill3Button.interactable = false;
                        anim.SetFloat("Blend", (skill.activeTime - tempActiveTime3)*2);

                        //activeTime.value = tempActiveTime3 / skill.activeTime;
                    }
                    else
                    {
                        StartCoroutine(PlayerController.Instance.currentState.SkillFinished());
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

    public void ActivateSkill(Player_BaseAbility skill)
    {
        //Debug.Log(skill.name);
        skill.Activate(player);
        StartCoroutine(skill.AbilityEffect());
        skill.state = Player_BaseAbility.AbilityState.active;
        //sets the current state to skillstate
        StartCoroutine(PlayerController.Instance.currentState.SkillState());
    }

    public void SelectingAbility()
    {
        //reset list
        displaySkillList.Clear();

        int amountToDisplay = 3;
        int rand;

        //choose ability to display
        for (int i = 0; i < amountToDisplay; i++)
        {
            rand = Player_PerksManager._random.Next(0, totalSkillList.Count);

            while (selectedSkillList.Contains(totalSkillList[rand]) || displaySkillList.Contains(totalSkillList[rand]))
            {
                rand = Player_PerksManager._random.Next(0, totalSkillList.Count);
            }

            displaySkillList.Add(totalSkillList[rand]);
        }
        DisplayAbility();
    }

    public void DisplayAbility()
    {
        skill1Obj.SetActive(false);
        skill2Obj.SetActive(false);
        skill3Obj.SetActive(false);

        //display perks
        for (int i = 0; i < displaySkillList.Count; i++)
        {
            switch (i)
            {
                case 0:
                    skill1Obj.gameObject.SetActive(true);
                    skill1Logo.sprite = displaySkillList[i].logo;
                    skill1Desc.text = displaySkillList[i].description;
                    skill1Name.text = displaySkillList[i].name;
                    break;

                case 1:
                    skill2Obj.gameObject.SetActive(true);
                    skill2Logo.sprite = displaySkillList[i].logo;
                    skill2Desc.text = displaySkillList[i].description;
                    skill2Name.text = displaySkillList[i].name;
                    break;

                case 2:
                    skill3Obj.gameObject.SetActive(true);
                    skill3Logo.sprite = displaySkillList[i].logo;
                    skill3Desc.text = displaySkillList[i].description;
                    skill3Name.text = displaySkillList[i].name;
                    break;
            }
        }
    }

    public void ChooseAbility(int abilityNum)
    {
        //if there are less than 3 abilities and they are already not selected
        if(selectedSkillList.Count < 3  && !selectedSkillList.Contains(displaySkillList[abilityNum]))
        {
            switch (abilityNum)
            {
                case 0:
                    selectedSkillList.Add(displaySkillList[abilityNum]);
                    break;

                case 1:
                    selectedSkillList.Add(displaySkillList[abilityNum]);
                    break;

                case 2:
                    selectedSkillList.Add(displaySkillList[abilityNum]);
                    break;
            }
        }

        UpdateAbilityChosen();
        SelectingAbility();

    }

    public void UpdateAbilityChosen()
    {
        switch(selectedSkillList.Count)
        {
            case 1:
                skill1 = selectedSkillList[0];
                break;
            case 2:
                skill1 = selectedSkillList[0];
                skill2 = selectedSkillList[1];
                break;
            case 3:
                skill1 = selectedSkillList[0];
                skill2 = selectedSkillList[1];
                skill3 = selectedSkillList[2];
                break;
        }
    }
    #endregion
}
