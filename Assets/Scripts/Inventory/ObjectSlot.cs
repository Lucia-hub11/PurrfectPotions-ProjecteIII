using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSlot : MonoBehaviour
{
    public string objectName;
    public DragDropObjects dragdrop;
    public bool isFull;

    [SerializeField]
    private Image itemImage; //la que apareix

    public GameObject ObtainedText;
    public Image obtainedImage;


    void Start()
    {
        ObtainedText.SetActive(false);
    }

    public void AddObjectSprite(string ingredientName, Sprite itemSprite)//bueno li he canviat el nom per si de cas donava problemes que fos el mateix, per provar
    {
        
        this.objectName = ingredientName;
        isFull = true;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
        itemImage.gameObject.SetActive(true);
        itemImage.enabled = true;
        itemImage.canvasRenderer.SetAlpha(1f);

        obtainedImage.GetComponent<Image>().sprite = itemSprite;//perquè apareixi al text 'Has obtingut un objecte!'

        ObtainedText.SetActive(true);
        Invoke("HideText", 3f);
        
    }

    private void HideText()
    {
        ObtainedText.SetActive(false);
    }

    public void ClearObject()
    {
        objectName = "";
        isFull = false;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }

}
