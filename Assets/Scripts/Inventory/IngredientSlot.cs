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

    public GameObject ObtainedText;

    void Start()
    {
        itemImage.gameObject.SetActive(false);
        ObtainedText.SetActive(false);
    }

    public void AddIngredientSprite(string ingredientName, Sprite itemSprite)
    {
        itemImage.gameObject.SetActive(true);
        this.ingredientName = ingredientName;
        isFull = true;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
        ObtainedText.SetActive(true);
        Invoke("HideText", 5f);
    }

    private void HideText()
    {
        ObtainedText.SetActive(false);
    }
    public void ClearIngredient()
    {
        ingredientName = "";
        isFull = false;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }
}
