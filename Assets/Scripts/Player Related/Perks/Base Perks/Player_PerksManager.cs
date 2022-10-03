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
        
    }
    
    public void UpdatePerk(PerkModifiers perkMod)
    {
        for (int i = 0; i < totalModifiers.Count; i++)
        {
            perkMod = totalModifiers[i].perks.ApplyPerks(perkMod);
        }

        //do something with perkMod
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
