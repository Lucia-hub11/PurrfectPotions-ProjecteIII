using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public StartMemoryGame memoryGame;
    public CrowTalk crowTalk;
    public GameObject Code;
    bool crowDimond = false;

    [SerializeField] 
    private string ingredientName;

    public Sprite ingredientSprite;

    public float ingredientRange = 4;
    public GameObject interactText;

    private InventoryManager inventoryManager;
    private BottomInventoryManager fromObjectsBottomInventoryManager;
    private BottomInventoryManager fromIngredientsBottomInventoryManager;
    private InputController _inputController;
    private Transform playerTransform;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ingredientRange);
    }

    void Start()
    {
        // buscar el Player i el InputController assignat
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        _inputController = player.GetComponent<InputController>();
        //buscar l'Inventory
        GameObject inventoryObject = GameObject.Find("InventoryCanvas");
        GameObject objectsBottom = GameObject.Find("BottomObjectsCanvas");
        GameObject ingredientsBottom = GameObject.Find("BottomIngredientsCanvas");

        inventoryManager = inventoryObject.GetComponent<InventoryManager>();
        fromObjectsBottomInventoryManager = objectsBottom.GetComponent<BottomInventoryManager>();
        fromIngredientsBottomInventoryManager = ingredientsBottom.GetComponent<BottomInventoryManager>();

        Code.SetActive(false);

        //text 'Clica E per agafar'
        if (interactText != null)
        {
            interactText.SetActive(false);
        }   
    }

    private void Update()
    {
        //rang al voltant del ingredient
        bool isInRange = Vector3.Distance(transform.position, playerTransform.position) < ingredientRange;

        if (interactText != null)
        {
            if (isInRange)
            {
                //Debug.Log("player esta al range!");
                interactText.SetActive(true);
            }
            else //cada model t� un text per separat pq si no es barallen
            {
                interactText.SetActive(false);
            }
        } // simplificat seria aixi if (interactText) interactText.SetActive(isInRange);

        if (isInRange && _inputController.Interact)
        {
            if(ingredientName=="Invisible Mushroom")
            {
                memoryGame.JocMemory(this);
                //Destroy(interactText);
                interactText.SetActive(false);
            }
            else if (ingredientName == "Diamond")
            {
                Code.SetActive(true);
                interactText.SetActive(false);
            }
            else if(ingredientName=="Crow Feather"){
                if (crowDimond == false)
                {
                    crowTalk.ShowCrowTalk();
                }
                else
                {
                    crowTalk.ShowCrowThanks();
                }

            }
            else
            {
                CollectIngredient();
                interactText.SetActive(false);
            }
        } 
    }
    public void CollectIngredient()
    {
        if (gameObject.tag == "Ingredient")
        {
            if(ingredientName== "Crow Feather")//el mateix però sense destruir-lo
            {
                inventoryManager.AddIngredient(ingredientName, ingredientSprite);
                fromIngredientsBottomInventoryManager.AddIngredient(ingredientName, ingredientSprite);
                interactText.SetActive(false);
                crowDimond = true;
            }
            else
            {
                inventoryManager.AddIngredient(ingredientName, ingredientSprite);
                fromIngredientsBottomInventoryManager.AddIngredient(ingredientName, ingredientSprite);
                Destroy(gameObject);
                interactText.SetActive(false);
            }
        }
        else if (gameObject.tag == "Object")
        {
            inventoryManager.AddObject(ingredientName, ingredientSprite);//canviar per funcio addobject del inventory Manager
            fromObjectsBottomInventoryManager.AddObject(ingredientName, ingredientSprite);
            Destroy(gameObject);
            interactText.SetActive(false);
        }
        else
        {
            Debug.Log("No hi ha cap tag Ingredient o Objecte");
        }

    }
}
