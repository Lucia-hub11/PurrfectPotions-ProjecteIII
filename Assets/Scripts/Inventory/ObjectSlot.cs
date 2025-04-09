using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSlot : MonoBehaviour
{
    public string ingredientName;
    public bool isFull;

    [SerializeField]
    private Image itemImage; //la que apareix

    public void AddObjectSprite(string ingredientName, Sprite itemSprite)//bueno li he canviat el nom per si de cas donava problemes que fos el mateix, per provar
    {
        this.ingredientName = ingredientName;
        isFull = true;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
    }
}
