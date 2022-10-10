using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PerksManager : MonoBehaviour
{
    //created by Alex

    public static Player_PerksManager Instance { get; private set; }

    [Header("Modifiers")]
    public List<Modifier> totalModifiers = new();
    PerkModifiers tempPerks = new();

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
      
    }

    public PerkModifiers UpdatePerk(PerkModifiers perkMod)
    {

        //foreach perk in the list, apply all of them
        for (int i = 0; i < totalModifiers.Count; i++)
        {
            tempPerks = totalModifiers[i].perks.ApplyPerks(tempPerks);
        }

        //do something with perkMod
        #region ApplyAllPerks

        perkMod = tempPerks;

        return perkMod;
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
