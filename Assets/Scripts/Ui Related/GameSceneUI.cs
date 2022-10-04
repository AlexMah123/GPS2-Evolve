using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    //HYZ
    //GameScene
    [SerializeField] private GameObject perkWindow;
    [SerializeField] private GameObject evoWindow;
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private GameObject settingsWindow;

    private void Update()
    {
        // REDO after input system is complete
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Input.GetKeyDown("Cancel"))
            {
                TogglePause();
                Debug.Log(Time.timeScale);
            }
        }
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
