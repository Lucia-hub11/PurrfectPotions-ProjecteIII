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
    private Image itemImage;

    public GameObject ObtainedText;
    public Image obtainedImage;

    private Sprite spriteWait;

    public AudioSource externalSoundSource;
    public AudioClip obtainedClip;

    void Start()
    {
        ObtainedText.SetActive(false);
        CloverThoughts.SetActive(false);
    }

    public void AddIngredientSprite(string ingredientName, Sprite itemSprite)
    {
        this.ingredientName = ingredientName;
        if (ingredientName == "Tear")
        {
            CloverThoughts.SetActive(true);
            spriteWait = itemSprite;
            Invoke("RegularAddSprite", 4f);
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

        PlayObtainedSound();

        itemImage.canvasRenderer.SetAlpha(1f);
        obtainedImage.GetComponent<Image>().sprite = itemSprite;

        Invoke("HideText", 3f);
    }

    private void PlayObtainedSound()
    {
        if (externalSoundSource != null && obtainedClip != null)
        {
            externalSoundSource.PlayOneShot(obtainedClip);
        }
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