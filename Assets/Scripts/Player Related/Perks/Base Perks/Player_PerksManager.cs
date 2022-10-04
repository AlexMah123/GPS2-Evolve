using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PerksManager : MonoBehaviour
{
    //created by Alex, WIP
    [Header("Modifiers")]
    public List<Modifier> totalModifiers = new List<Modifier>();
    PerkModifiers currentPerk = new();

    private void Start()
    {
        //UpdatePerk(currentPerk);
        //UpdatePerk(currentPerk);
    }

    public void UpdatePerk(PerkModifiers perkMod)
    {
        //resets the struct passed in
        perkMod = new();

        //foreach perk in the list, apply all off them
        for (int i = 0; i < totalModifiers.Count; i++)
        {
            perkMod = totalModifiers[i].perks.ApplyPerks(perkMod);
        }

        //do something with perkMod
        #region ApplyAllPerks
        //sets currentPerk to all the modifiers gotten
        currentPerk = perkMod;
        Debug.Log(currentPerk.attackModifier);

        #endregion
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
