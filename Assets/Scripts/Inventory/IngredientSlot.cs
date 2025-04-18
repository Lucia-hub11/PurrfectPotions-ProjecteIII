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
        ObtainedText.SetActive(false);
    }

    public void AddIngredientSprite(string ingredientName, Sprite itemSprite)
    {
        
        this.ingredientName = ingredientName;
        isFull = true;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
        itemImage.gameObject.SetActive(true);
        ObtainedText.SetActive(true);
        itemImage.enabled = true;
        itemImage.canvasRenderer.SetAlpha(1f);

        Invoke("HideText", 5f);
    }

    private void HideText()
    {
        ObtainedText.SetActive(false);
    }
}
