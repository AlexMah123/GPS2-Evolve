using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private GameObject overheal;
    [SerializeField] private Slider overhealSlider;
    [SerializeField] private Slider evo;

    [Header("Objective")]
    [SerializeField] private Button info;
    [SerializeField] private TextMeshProUGUI obj1;
    [SerializeField] private TextMeshProUGUI obj2;
    [SerializeField] private TextMeshProUGUI obj3;
    [SerializeField] private TextMeshProUGUI obj4;
    [SerializeField] private Transform objective;
    public static float armedK;
    public static bool rTower;
    public static bool eCamp;
    public static bool fBoss;

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

        if(Player_StatusManager.Instance.playerStats.OverHeal)
        {
            if(Player_StatusManager.Instance.playerStats.CurrOverheal > 0)
            {
                if (!overheal.activeSelf)
                {
                    overheal.SetActive(true);
                }

                overhealSlider.value = ((float)Player_StatusManager.Instance.playerStats.CurrOverheal / Player_StatusManager.Instance.playerStats.MaxOverheal);
            }
            else
            {
                if(overheal.activeSelf)
                {
                    overheal.SetActive(false);
                }
            }

        }
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

        #region obj
        obj1.text = $"Kill Armed Human<indent=85%> {armedK}/5 </indent>";
        obj1.text = armedK >= 5 ? $"<s><color=green>{obj1.text}</color></s>" : $"<color=red>{obj1.text}</color>";
        obj2.text = rTower ? $"<s><color=green>Destroy Radio Tower</color></s>" : $"<color=red>Destroy Radio Tower</color>";
        obj3.text = eCamp ? $"<s><color=green>Destroy Enemy Camp</color></s>" : $"<color=red>Destroy Enemy Camp</color>";
        obj4.text = fBoss ? $"<s><color=green>Defeat Final Boss</color></s>" : $"<color=red>Defeat Final Boss</color>";

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
        if(PlayerController.playerInput.UI.Test.WasPressedThisFrame())
        {
            armedK += 1;
            rTower = !rTower;
            eCamp = !eCamp;
            fBoss = !fBoss;
        }
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
        Time.timeScale = pauseWindow.activeSelf ? 0.0f : 1.0f;
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

    public void DisplayWindow()
    {
        Vector3 closedPos = new(-1132.5f, objective.localPosition.y, 1);
        Vector3 openPos = new(-632, objective.localPosition.y, 1);
        if (objective.localPosition.x >= openPos.x)
        {
            StopCoroutine(CloseObj(closedPos, 1));
            StartCoroutine(CloseObj(closedPos, 1));
        }
        else if (objective.localPosition.x <= closedPos.x)
        {
            StopCoroutine(OpenObj(openPos, 1));
            StartCoroutine(OpenObj(openPos, 1));
        }
    }

    IEnumerator CloseObj (Vector3 close, float dura)
    {
        float time = 0;
        info.enabled = false;
        while (time < dura)
        {
            objective.localPosition = Vector3.Lerp(objective.localPosition, close, time / dura);
            time += Time.deltaTime;
            yield return null;
        }
        info.enabled = true;
        objective.localPosition = close;
    }
    IEnumerator OpenObj (Vector3 open, float dura)
    {
        float time = 0;
        info.enabled = false;
        while (time < dura)
        {
            objective.localPosition = Vector3.Lerp(objective.localPosition, open, time / dura);
            time += Time.deltaTime;
            yield return null;
        }
        info.enabled = true;
        objective.localPosition = open;
    }
}
