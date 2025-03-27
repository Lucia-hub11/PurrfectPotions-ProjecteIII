using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    public string ingredientName;
    public Sprite itemSprite; //si l'altra es desto pq aquesta?
    public bool isFull;

    [SerializeField]
    private Image itemImage; //en teoria la q apareix?

    public void AddIngredientSprite(string ingredientName, Sprite itemSprite)
    {
        this.ingredientName = ingredientName;
        this.itemSprite = itemSprite;
        isFull = true;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
    }
}
