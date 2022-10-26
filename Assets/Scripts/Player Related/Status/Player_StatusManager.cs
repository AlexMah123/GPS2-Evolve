using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_StatusManager : MonoBehaviour
{
    //created by Alex
    public static Player_StatusManager Instance;

    [SerializeField] Transform player;
    [HideInInspector] public Player_Base playerBaseStats = new();
    public Player_Base playerStats = new();
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
        UpdatePlayerStats();
        //Debug.Log("RESETING");
        //playerStats.Reset();
    }

    private void Update()
    {
        //run the update effects on perk if selectedMod List has something
        if (Player_PerksManager.Instance.selectedModList.Count > 0)
        {
            Player_PerksManager.Instance.UpdateEffects(playerStats);
        }
    }

    public void UpdatePlayerStats()
    {
        //updates and takes all the current selectedMods in the list and applies them
        playerPerks = Player_PerksManager.Instance.UpdatePerk(playerPerks);

        #region base properties
        //playerStats.CurrHealth = playerBaseStats.CurrHealth;
        playerStats.MaxHealth = playerBaseStats.MaxHealth + playerPerks.healthModifier;
        playerStats.Defence = playerBaseStats.Defence + playerPerks.defenceModifier;
        playerStats.Attack = playerBaseStats.Attack + playerPerks.attackModifier;
        playerStats.AttackSpeed = playerBaseStats.AttackSpeed + playerPerks.attackSpeedModifier;
        playerStats.Speed = playerBaseStats.Speed + playerPerks.speedModifier;
        playerStats.JumpHeight = playerBaseStats.JumpHeight + playerPerks.jumpHeightModifier;
        playerStats.EatHeal = playerBaseStats.EatHeal + playerPerks.eatHealModifier;
        playerStats.EatTime = playerBaseStats.EatTime + playerPerks.eatHealModifier;
        playerStats.BuffExtend = playerBaseStats.BuffExtend + playerPerks.buffExtendModifier;
        playerStats.Size = playerBaseStats.Size + playerPerks.sizeModifier;
        player.transform.localScale = new Vector3(playerStats.Size, playerStats.Size, playerStats.Size);
        #endregion

    }
}
