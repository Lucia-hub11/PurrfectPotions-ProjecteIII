using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Codigo para generar las fichas

public class Fiches : MonoBehaviour
{
    [SerializeField] private Image iconImage;

    public Sprite hiddenIconSprite;
    public Sprite iconSprite;

    public bool isSelected;

    public ComportamentFiches controller;

    public void OnCardClick()
    {
        controller.SetSelected(this);
    }

    public void SetIconSprite(Sprite sp)
    {
        iconSprite = sp;
    }

    public void Show()
    {
        iconImage.sprite = iconSprite;
        isSelected = true;
    }

    public void Hide()
    {
        iconImage.sprite = hiddenIconSprite;
        isSelected = false;
    }
}
