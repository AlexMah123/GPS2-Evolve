using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    //created by HYZ, edited by Alex
    PlayerController PlayerController;
    //GameScene
    [SerializeField] private GameObject perkWindow;
    [SerializeField] private GameObject abilityWindow;
    [SerializeField] private GameObject evoWindow;
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private Button devourButton;
    [SerializeField] private Slider health;
    [SerializeField] private Slider evo;
    private bool t1;
    private bool t2;

    private void Awake()
    {
        PlayerController = PlayerController.Instance;
    }

    private void Update()
    {
        #region health evo bar
        health.value = ((float)Player_StatusManager.Instance.playerStats.CurrHealth/ Player_StatusManager.Instance.playerStats.MaxHealth);
        evo.value = ((float)Player_StatusManager.Instance.playerStats.CurrEvolveBar/ Player_StatusManager.Instance.playerStats.MaxEvolveBar);
        #endregion

        #region devourButton
        if (PlayerController.Instance.devouring)
        {
            devourButton.interactable = false;
        }
        else if (PlayerController.Instance.inRangeDevour)
        {
            devourButton.interactable = true;
        }
        else
        {
            devourButton.interactable = false;
        }
        #endregion

        if (Player_StatusManager.Instance.one && !t1) 
        {
            TogglePerk();
            t1 = true; 
        }
        else if(Player_StatusManager.Instance.two && !t2)
        {
            TogglePerk();
            t2 = true;
        }
        else if (Player_StatusManager.Instance.three)
        {
            ToggleAbility();
            Player_StatusManager.Instance.playerStats.CurrEvolveBar = 0;
            t1 = false;
            t2 = false;
        }
        //if (Application.platform == RuntimePlatform.Android)
        //{
        /*if (PlayerController.playerInput.UI.Escape.WasPressedThisFrame())
            {
                TogglePause();
                Debug.Log(Time.timeScale);
            }*/
        //}
    }

    public void TogglePerk()
    {
        perkWindow.SetActive(!perkWindow.activeSelf);
    }

    public void ToggleAbility()
    {
        abilityWindow.SetActive(!abilityWindow.activeSelf);
    }

    public void ToggleEvolve()
    {
        evoWindow.SetActive(!evoWindow.activeSelf);
    }

    public void TogglePause()
    {
        pauseWindow.SetActive(!pauseWindow.activeSelf);
        if(pauseWindow.activeSelf)
        {
            Time.timeScale = 0.0f;
        }
        else if(!pauseWindow.activeSelf)
        {
            Time.timeScale = 1.0f;
        }
        Debug.Log(Time.timeScale);
    }

    public void ToggleSettings()
    {
        pauseWindow.SetActive(!pauseWindow.activeSelf);
        settingsWindow.SetActive(!settingsWindow.activeSelf);
    }

    public void LvlUp()
    {
        TogglePerk();
    }
}
