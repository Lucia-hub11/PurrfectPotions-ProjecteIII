using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    public string ingredientName;
    public bool isFull;
    public GameObject CloverThoughts;

    [SerializeField]
    private Image itemImage; //la que apareix

    public GameObject ObtainedText;

    private Sprite spriteWait;

    void Start()
    {
        ObtainedText.SetActive(false);
    }

    public void AddIngredientSprite(string ingredientName, Sprite itemSprite)
    {
        this.ingredientName = ingredientName;
        if (ingredientName == "Tear")
        {
            CloverThoughts.SetActive(true);
            spriteWait = itemSprite;
            Invoke("RegularAddSprite", 2f);

        }
        else
        {
            RegularAdd(itemSprite);
        }
    }

    private void RegularAddSprite()
    {
        RegularAdd(spriteWait);
    }


    private void RegularAdd(Sprite itemSprite)
    {
        isFull = true;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
        itemImage.gameObject.SetActive(true);
        CloverThoughts.SetActive(false);
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
