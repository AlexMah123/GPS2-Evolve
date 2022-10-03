using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //HYZ
    [SerializeField] private GameObject loadScreen;
    [SerializeField] private Slider loadVal;

    public void SwitchScene(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }
    public void ButtonTest()
    {
        Debug.Log("Button Clicked");
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
