using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_PerksManager : MonoBehaviour
{
    //created by Alex

    //init random 
    public static System.Random _random = new();

    public static Player_PerksManager Instance { get; private set; }

    [Header("Modifiers")]
    [NonReorderable] public List<Modifier> totalModList = new();
    public List<Modifier> displayModList = new();
    public List<Modifier> selectedModList = new();
    PerkModifiers tempPerks;

    [Header("Perks UI Variables")]
    [SerializeField] GameObject perk1;
    [SerializeField] Image perk1Logo;
    [SerializeField] TextMeshProUGUI perk1Desc;
    [SerializeField] TextMeshProUGUI perk1Name;

    [SerializeField] GameObject perk2;
    [SerializeField] Image perk2Logo;
    [SerializeField] TextMeshProUGUI perk2Desc;
    [SerializeField] TextMeshProUGUI perk2Name;

    [SerializeField] GameObject perk3;
    [SerializeField] Image perk3Logo;
    [SerializeField] TextMeshProUGUI perk3Desc;
    [SerializeField] TextMeshProUGUI perk3Name;

    [Header("Selected Perks Display")]
    [SerializeField] GameObject sPerk;
    [SerializeField] GameObject content;

    private void Awake()
    {
        
        #region Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        #endregion
    }

    public void SelectedPerkDisplay(int i)
    {
        GameObject s = sPerk;
        s.GetComponentInChildren<Image>().sprite = selectedModList[i].perks.perkLogo;
        s.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = selectedModList[i].perks.name;
        s.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = selectedModList[i].perks.description;
        s.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = selectedModList[i].perks.effect; 
        Instantiate(s, content.transform);
    }
    public void AllSelectedPerkDisplay()
    {
        for (int i = 0; i < selectedModList.Count; i++)
        {
            GameObject s = sPerk;
            s.GetComponentInChildren<Image>().sprite = selectedModList[i].perks.perkLogo;
            s.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = selectedModList[i].perks.name;
            s.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = selectedModList[i].perks.description;
            Instantiate(s, content.transform);
        } 
    }

    private void Start()
    {
        //TESTING
        /*for(int i=0; i<15; i++)
        {
            selectedModList.Add(totalModList[i]);
        }*/


        AwakePerks();
        Player_StatusManager.Instance.UpdatePlayerStats();
        SelectingPerk();
        AllSelectedPerkDisplay();
    }

    #region PerkFunction
    public void AwakePerks()
    {
        for (int i = 0; i < selectedModList.Count; i++)
        {
            selectedModList[i].perks.Awake();
        }
    }

    public PerkModifiers UpdatePerk(PerkModifiers perkMod)
    {
        tempPerks = new();
        //foreach perk in the list, apply all of them
        for (int i = 0; i < selectedModList.Count; i++)
        {
            tempPerks = selectedModList[i].perks.ApplyPerks(tempPerks);
        }

        //do something with perkMod
        #region ApplyAllPerks

        perkMod = tempPerks;

        return perkMod;
        #endregion
    }

    public void UpdateEffects(Player_Base playerObj)
    {
        //foreach status in the selectedMod list, apply all of them
        for (int i = 0; i < selectedModList.Count; i++)
        {
            selectedModList[i].perks.ApplyEffects(playerObj);
        }
    }

    public void SelectingPerk()
    {
        //reset list
        displayModList.Clear();

        //if there are less than 3 perks to show, show the remaing amount
        int amountToDisplay = selectedModList.Count <= 12 ? amountToDisplay = 3 : amountToDisplay = totalModList.Count - selectedModList.Count;
        int rand;

        //choose perks to display
        for (int i = 0; i < amountToDisplay; i++)
        {
            rand = _random.Next(0, totalModList.Count);

            while(selectedModList.Contains(totalModList[rand]) || displayModList.Contains(totalModList[rand]))
            {
                rand = _random.Next(0, totalModList.Count);
            }

            displayModList.Add(totalModList[rand]);
        }
        DisplayPerks();
    }

    public void DisplayPerks()
    {
        //resets the perks
        perk1.SetActive(false);
        perk2.SetActive(false);
        perk3.SetActive(false);

        //display perks
        for (int i = 0; i < displayModList.Count; i++)
        {
            switch (i)
            {
                case 0:
                    perk1.gameObject.SetActive(true);
                    perk1Logo.sprite = displayModList[i].perks.perkLogo;
                    perk1Desc.text = displayModList[i].perks.description;
                    perk1Name.text = displayModList[i].perks.name;

                    break;

                case 1:
                    perk2.gameObject.SetActive(true);
                    perk2Logo.sprite = displayModList[i].perks.perkLogo;
                    perk2Desc.text = displayModList[i].perks.description;
                    perk2Name.text = displayModList[i].perks.name;
                    break;

                case 2:
                    perk3.gameObject.SetActive(true);
                    perk3Logo.sprite = displayModList[i].perks.perkLogo;
                    perk3Desc.text = displayModList[i].perks.description;
                    perk3Name.text = displayModList[i].perks.name;
                    break;
            }
        }
    }

    public void ChoosePerk(int perkNum)
    {
        if(!selectedModList.Contains(displayModList[perkNum]))
        {
            switch (perkNum)
            {
                case 0:
                    selectedModList.Add(displayModList[perkNum]);
                    SelectedPerkDisplay(selectedModList.Count - 1);
                    break;

                case 1:
                    selectedModList.Add(displayModList[perkNum]);
                    SelectedPerkDisplay(selectedModList.Count - 1);
                    break;

                case 2:
                    selectedModList.Add(displayModList[perkNum]);
                    SelectedPerkDisplay(selectedModList.Count - 1);
                    break;
            }

            //after choose, run awake, run updateplayerstats
            AwakePerks();
            //SelectedPerkDisplay();
            SelectingPerk();
            Player_StatusManager.Instance.UpdatePlayerStats();
            Debug.Log($"Selected Perk, Applying");

        }
    }

    #endregion
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
