using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Smash", menuName = "PlayerAbility/Smash")]
public class Smash : Player_BaseAbility
{
    //created by Alex

    public override void Awake()
    {

    }

    public override void Activate(GameObject parent)
    {
        //activate ability
    }

    public override IEnumerator AbilityEffect()
    {

        yield break;
    }
}
