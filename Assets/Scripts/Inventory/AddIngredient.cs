using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddIngredient : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;

    [SerializeField]
    private Image itemImage;

    public void AddIngredi(string ingredientName, Sprite itemSprite)
    {
        isFull = true;
        itemImage.sprite = itemSprite;
    }
}
