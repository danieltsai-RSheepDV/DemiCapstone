using System;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class VisNovImage : MonoBehaviour
{
    Image image;
    [SerializeField] private Sprite[] images;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    [YarnCommand("change_image")]
    public void ChangeImage(int index)
    {
        image.sprite = images[index];
    }
}
