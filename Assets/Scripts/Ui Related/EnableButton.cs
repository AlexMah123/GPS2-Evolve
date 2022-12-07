using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Enable());
    }

    private void OnDisable()
    {
        StopCoroutine(Enable());
    }
    private void Update()
    {
        Debug.Log(Time.timeScale);
    }
    public IEnumerator Enable()
    {
        yield return new WaitForSeconds(2);
        Button button = gameObject.GetComponent<Button>();
        button.interactable = true;

    }
}
