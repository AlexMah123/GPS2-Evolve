using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Metabolism", menuName = "PlayerPerks/HealthDefense/Metabolism")]
public class Metabolism : Player_BasePerk
{
    //created by Alex

    [Header("Metabolism - Perk Details")]
    [SerializeField] int maxHealth = -50;
    [SerializeField] float regenPerSecond = 1f;
    float temp;


    public override void Awake()
    {
        temp = regenPerSecond;
    }

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.healthModifier += maxHealth;
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        if((temp -= Time.deltaTime) < 0)
        {
            playerObj.CurrHealth += 3;
            temp = regenPerSecond;
        }
    }

}
