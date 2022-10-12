using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_StatusManager : MonoBehaviour
{
    //created by Alex
    public static Player_StatusManager Instance;

    public Player_Base playerBaseStats = new();
    public PerkModifiers playerPerks = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
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
        playerPerks = Player_PerksManager.Instance.UpdatePerk(playerPerks);

        //Debug.Log(playerPerks.attackModifier);

    }

    private void Update()
    {
        
    }
}
