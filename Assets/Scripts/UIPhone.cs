using System;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class UIPhone : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    [YarnCommand("SetShowing")]
    public void SetShowing(bool showing)
    {
        image.enabled = showing;
    }
}
