using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI play;
    private bool forward;
    private bool backward;
    private float alpha = 255;
    // Update is called once per frame
    public void Update()
    {
        if (alpha >= 255)
        {
            forward = false;
        }
        else if (alpha <= 0)
        {
            forward = true;
        }
        if (forward)
        {
            alpha += Time.deltaTime * 255/2;
        }
        else if (!forward)
        {
            alpha -= Time.deltaTime * 255/2;
        }

        play.color = new Color(1, 1, 1,alpha/255);
    }
}
