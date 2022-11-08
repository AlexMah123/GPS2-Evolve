using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bite" , menuName = "PlayerAbility/Bite")]
public class Bite_Ability : Player_BaseAbility
{
    //created by Alex
    [SerializeField] int damage = 40;

    public override void Awake()
    {

    }

    public override void Activate(GameObject parent)
    {
        //activate ability
    }

    public override IEnumerator AbilityEffect(Player_BaseAbility skill, GameObject parent)
    {

        yield break;
    }
}
