using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WellPrepared", menuName = "PlayerPerks/Attack/WellPrepared")]
public class WellPrepared : Player_BasePerk
{
    //created by Alex
    [Header("Well Prepared - Perk Details")]
    [SerializeField] int statusModifier = 7;
    [SerializeField] float healthPercent = 0.75f;

    bool effectActive;
    bool runOnce;

    public override void Awake()
    {
        effectActive = false;
        runOnce = false;
    }

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        //checks if effect is active, and takes in the players attack
        effectActive = playerObj.CurrHealth >= playerObj.MaxHealth * healthPercent ? effectActive = true : effectActive = false;

        //if effect is not active and the effect has been applied before, revert.
        if (!effectActive && runOnce)
        {
            playerObj.Attack -= statusModifier;
            runOnce = false;
            //Debug.Log("inactive, effect ran before, reverting");
        }
        else if(effectActive && !runOnce) //if effect is active and effect has not been applied, apply it.
        {
            playerObj.Attack += statusModifier;
            runOnce = true;
            //Debug.Log("active, running once");
        }

    }
}
