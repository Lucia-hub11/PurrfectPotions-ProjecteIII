using System;
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
    //[SerializeField] private Button skipButton;

    public GameObject ObtainedText;

    private Sprite spriteWait;
    /*private void Awake()
    {
        if (skipButton != null)
            skipButton.onClick.AddListener(OnSkipClick);
    }*/

    /*public void OnSkipClick()
    {
        CancelInvoke(nameof(RegularAddSprite));
        CloverThoughts.SetActive(false);
        if (spriteWait != null)
            RegularAdd(spriteWait);
    }*/

    void Start()
    {
        ObtainedText.SetActive(false);
        CloverThoughts.SetActive(false);//aixo no sé pq no ho fa
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
    public void ClearIngredient()
    {
        ingredientName = "";
        isFull = false;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }
}
