using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //HYZ
    [SerializeField] private GameObject loadScreen;
    [SerializeField] private Slider loadVal;
    [SerializeField] private Sprite[] loadPic;
    [SerializeField] private Image loadImage;

    [Header("Settings")]
    [SerializeField] private Slider volSlider;
    [SerializeField] private Slider horSlider;
    [SerializeField] private Slider verSlider;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private TextMeshProUGUI volVal;
    [SerializeField] private TextMeshProUGUI horVal;
    [SerializeField] private TextMeshProUGUI vertVal;
    [SerializeField] private CinemachineFreeLook CFL;
    private float val;
    private void Awake()
    {
        bool vol = mixer.GetFloat("Master", out var val);
        if (vol)
        {
            volVal.text = Mathf.Round(Mathf.Pow(10,val/20) * 100).ToString();
            volSlider.value = Mathf.Round(Mathf.Pow(10, val / 20));
        }
        else
        {
            volVal.text = "0";
        }
        horVal.text = "1";
        vertVal.text = "1";
    }

    public void SwitchScene(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }

    public void UpdateVolume()
    {
        mixer.SetFloat("Master", Mathf.Log(volSlider.value) * 20f);
        volVal.text = Mathf.Round(volSlider.value * 100).ToString();
    }
    public void UpdateHorizontal()
    {
        CFL.m_XAxis.m_MaxSpeed = 75 * horSlider.value;
        horVal.text = horSlider.value.ToString("0.00");

    }
    public void UpdateVertical()
    {
        CFL.m_YAxis.m_MaxSpeed = 0.2f * verSlider.value;
        vertVal.text = verSlider.value.ToString("0.00");
    }
    IEnumerator LoadScene(int sceneIndex)
    {
        loadImage.sprite = loadPic[Random.Range(0, loadPic.Length)];
        loadScreen.SetActive(true);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneIndex);
        Time.timeScale = 1;

        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            loadVal.value = progress;
            Debug.Log("Loaded");
            yield return null;
        }
    }
}
