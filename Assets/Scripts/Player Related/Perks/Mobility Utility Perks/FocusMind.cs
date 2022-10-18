using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FocusMind", menuName = "PlayerPerks/MobilityUtility/FocusMind")]
public class FocusMind : Player_BasePerk
{
    //created by Alex
    [Header("FocusMind - Perk Details")]
    [SerializeField] int statusModifier = 5;
    [SerializeField] float duration = 3f;

    float temp;
    bool effectActive;
    bool runOnce;

    public override void Awake()
    {
        effectActive = false;
    }

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        //when skill is pressed, effect is active and duration is set
        if(PlayerController.Instance.playerInput.PlayerMain.Skill1.triggered || PlayerController.Instance.playerInput.PlayerMain.Skill2.triggered || PlayerController.Instance.playerInput.PlayerMain.Skill3.triggered)
        {
            effectActive = true;
            temp = duration + playerObj.BuffExtend;
        }

        //if duration runs out, effect is not active
        if ((temp -= Time.deltaTime) < 0 && effectActive)
        {
            effectActive = false;
        }

        //if effect is not active and the effect has been applied before, revert.
        if (!effectActive && runOnce)
        {
            playerObj.Attack -= statusModifier;
            runOnce = false;
            //Debug.Log("inactive, effect ran before, reverting");
        }
        else if (effectActive && !runOnce) //if effect is active and effect has not been applied, apply it.
        {
            playerObj.Attack += statusModifier;
            runOnce = true;
            //Debug.Log("active, running once");
        }
    }
}
