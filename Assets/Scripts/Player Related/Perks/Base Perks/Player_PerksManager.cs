using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PerksManager : MonoBehaviour
{
    //created by Alex

    [Header("Modifiers")]
    public List<Modifier> totalModifiers = new List<Modifier>();
    PerkModifiers currentPerk = new();

    private void Start()
    {
        UpdatePerk(currentPerk);
        //UpdatePerk(currentPerk);
    }

    public void UpdatePerk(PerkModifiers perkMod)
    {
        //resets the struct passed in
        perkMod = new();

        //foreach perk in the list, apply all of them
        for (int i = 0; i < totalModifiers.Count; i++)
        {
            perkMod = totalModifiers[i].perks.ApplyPerks(perkMod);
        }

        //do something with perkMod
        #region ApplyAllPerks
        //sets currentPerk to all the modifiers gotten
        currentPerk = perkMod;
        Debug.Log(currentPerk.attackModifier);
        Debug.Log(currentPerk.defenceModifier);


        #endregion
    }

    public void UpdateEffects()
    {
        //foreach status in the list, apply all of them
        for (int i = 0; i < totalModifiers.Count; i++)
        {
            totalModifiers[i].perks.ApplyEffects();
        }
    }
}

[Serializable]
public class Modifier
{
    public Player_BasePerk perks;

    public Modifier(Player_BasePerk perkMod)
    {
        perks = perkMod;
    }
}
