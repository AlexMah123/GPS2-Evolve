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

    [Header("Settings")]
    [SerializeField] private Slider volSlider;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private TextMeshProUGUI volVal;
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
    IEnumerator LoadScene(int sceneIndex)
    {
        loadScreen.SetActive(true);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneIndex);

        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            loadVal.value = progress;
            Debug.Log("Loaded");
            yield return null;
        }
    }
}
