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

    void Start()
    {
        itemImage.gameObject.SetActive(false);
    }

    public void AddIngredientSprite(string ingredientName, Sprite itemSprite)
    {
        itemImage.gameObject.SetActive(true);
        this.ingredientName = ingredientName;
        isFull = true;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
    }
}
