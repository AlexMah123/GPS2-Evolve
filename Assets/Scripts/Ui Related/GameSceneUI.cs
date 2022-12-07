using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    //created by HYZ, edited by Alex
    PlayerController PlayerController;

    //GameScene
    [SerializeField] private GameObject perkWindow;
    [SerializeField] private GameObject abilityWindow;
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject perkDisplay;
    [SerializeField] private Button devourButton;
    [SerializeField] private Slider health;
    [SerializeField] private GameObject overheal;
    [SerializeField] private Slider overhealSlider;
    [SerializeField] private Slider evo;
    [SerializeField] private TextMeshProUGUI timer;

    [Header("Objective")]
    [SerializeField] private Button info;
    [SerializeField] private TextMeshProUGUI obj1;
    [SerializeField] private TextMeshProUGUI obj2;
    [SerializeField] private TextMeshProUGUI obj3;
    [SerializeField] private TextMeshProUGUI obj4;
    [SerializeField] private Transform objective;
    public static float armedKilled;
    public static bool radioTowerDestroyed;
    public static float chemistLabDestroyed;
    public static bool enemyCampDestroyed;
    [SerializeField] private float countdownM;
    [SerializeField] private float countdownS;
    [SerializeField] private GameObject winScreen;

    //player evolve bar
    private bool t1;
    private bool t2;

    private void Awake()
    {

        PlayerController = PlayerController.Instance;
        countdownM = 12;
        countdownS = 0;
        armedKilled = 0;
        radioTowerDestroyed = false;
        chemistLabDestroyed = 0;
        enemyCampDestroyed = false;
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if (perkWindow.activeSelf || abilityWindow.activeSelf || settingsWindow.activeSelf || pauseWindow.activeSelf || perkDisplay.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
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
        if(PlayerController.Instance != null)
        {
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

            if (armedKilled >= 5 &&radioTowerDestroyed&& chemistLabDestroyed >= 2 && enemyCampDestroyed)
            {
                winScreen.SetActive(true);
            }
        }
        #endregion

        #region objectives
        obj1.text = $"Kill Armed Human<indent=80%> {armedKilled}/5 </indent>";
        obj1.text = armedKilled >= 5 ? $"<s><color=green>{obj1.text}</color></s>" : $"<color=red>{obj1.text}</color>";
        obj2.text = radioTowerDestroyed ? $"<s><color=green>Destroy Radio Tower</color></s>" : $"<color=red>Destroy Radio Tower</color>";
        obj3.text = chemistLabDestroyed >= 2? $"<s><color=green>Destroy Chem Lab<indent=80%> {chemistLabDestroyed}/2 </indent> </color></s>" : $"<color=red>Destroy Chem Lab<indent=80%> {chemistLabDestroyed}/2 </indent> </color>";
        obj4.text = enemyCampDestroyed ? $"<s><color=green>Destroy Enemy Camp</color></s>" : $"<color=red>Destroy Enemy Camp</color>";

        #endregion

        #region Player levelup
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

        #endregion
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

    IEnumerator Countdown()
    {
        while (countdownS > 0 || countdownM > 0)
        {
            if (countdownS == 0)
            {
                countdownM -= 1;
                countdownS = 60;
            }
            yield return new WaitForSeconds(1);
            countdownS -= 1;
            timer.text = $"{countdownM}:{countdownS:00}";
        }
        Player_StatusManager.Instance.playerStats.CurrHealth = 0;
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
