using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Whip", menuName = "PlayerAbility/Whip")]
public class Whip : Player_BaseAbility
{
    //created by Alex

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
