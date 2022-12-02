using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Enable", 2);
    }

    public void Enable()
    {
        Button button = gameObject.GetComponent<Button>();
        button.enabled = true;
    }
}
