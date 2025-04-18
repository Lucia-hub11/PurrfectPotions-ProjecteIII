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

    public GameObject ObtainedText;


    void Start()
    {
        ObtainedText.SetActive(false);
    }


    public void AddObjectSprite(string ingredientName, Sprite itemSprite)//bueno li he canviat el nom per si de cas donava problemes que fos el mateix, per provar
    {
        
        this.ingredientName = ingredientName;
        isFull = true;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
        itemImage.gameObject.SetActive(true);
        itemImage.enabled = true;
        itemImage.canvasRenderer.SetAlpha(1f);

        ObtainedText.SetActive(true);
        Invoke("HideText", 5f);
        
    }

    private void HideText()
    {
        ObtainedText.SetActive(false);
    }

}
