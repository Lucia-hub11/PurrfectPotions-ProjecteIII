using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    public string ingredientName;
    public bool isFull;

    [SerializeField]
    private Image itemImage; //la que apareix

    public void AddIngredientSprite(string ingredientName, Sprite itemSprite)
    {
        this.ingredientName = ingredientName;
        isFull = true;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
    }
}
