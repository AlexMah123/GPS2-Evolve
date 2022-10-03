using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    //HYZ
    //GameScene
    [SerializeField] private GameObject perkWindow;
    [SerializeField] private GameObject evoWindow;
    [SerializeField] private GameObject pauseWindow;

    private void Update()
    {

        // REDO after input system is complete
        if (Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKeyDown("Cancel"))
            {
                Debug.Log("paused");
                pauseWindow.SetActive(!pauseWindow.activeSelf);
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
    }
    public void LvlUp()
    {
        TogglePerk();
    }
}
