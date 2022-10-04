using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

[RequireComponent(typeof (Slider))]
public class VolSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public string volName;
    public TextMeshProUGUI txt;

    public void UpdateSlider(float value)
    {
        mixer.SetFloat(volName, Mathf.Log(value) * 20f);
        txt.text = Mathf.Round(value * 100).ToString();
    }
}
