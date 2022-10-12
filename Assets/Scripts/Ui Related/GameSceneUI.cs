using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    //HYZ
    private Player playerInput;
    [SerializeField] private Player_StatusManager player;
    //GameScene
    [SerializeField] private GameObject perkWindow;
    [SerializeField] private GameObject evoWindow;
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private Slider health;
    [SerializeField] private Slider evo;
    private int maxH;

    private void OnEnable()
    {
        playerInput = new Player();
        playerInput.Enable();
        maxH = player.playerBaseStats.Health;
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    private void Update()
    {
        health.value = ((float)player.playerBaseStats.Health/ maxH);
        evo.value = ((float)player.playerBaseStats.CurrEvolveBar/ player.playerBaseStats.MaxEvolveBar);
        //if (Application.platform == RuntimePlatform.Android)
        //{
            if(playerInput.UI.Escape.WasPressedThisFrame())
            {
                TogglePause();
                Debug.Log(Time.timeScale);
            }
        //}
    }
    public void TogglePerk()
    {
        perkWindow.SetActive(!perkWindow.activeSelf);
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
