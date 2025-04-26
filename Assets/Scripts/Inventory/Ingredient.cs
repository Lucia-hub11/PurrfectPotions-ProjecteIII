using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public StartMemoryGame memoryGame;
    public CrowTalk crowTalk;

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
            else if(ingredientName=="Crow Feather"){
                crowTalk.ShowCrowTalk();
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
        if (inventoryManager != null)
        {
            if(gameObject.tag == "Ingredient")
            {
                Debug.Log("aixo es un ingredient!!!");
                inventoryManager.AddIngredient(ingredientName, ingredientSprite);
                Destroy(gameObject);
                interactText.SetActive(false);
                crowTalk.HideCrowTalk();
            }
            else if (gameObject.tag == "Object")
            {
                Debug.Log("aixo es un OBJECTE!!!");
                inventoryManager.AddObject(ingredientName, ingredientSprite);//canviar per funcio addobject del inventory Manager
                Destroy(gameObject);
                interactText.SetActive(false);
            }
            else
            {
                Debug.Log("No hi ha cap tag Ingredient o Objecte");
            }
            
        }
        else
        {
            Debug.LogError("InventoryManager no est� assignat.");
        }

        if (fromObjectsBottomInventoryManager != null)
        {
            if (gameObject.tag == "Ingredient")
            {
                fromIngredientsBottomInventoryManager.AddIngredient(ingredientName, ingredientSprite);
                Destroy(gameObject);
                crowTalk.HideCrowTalk();
            }
            else if (gameObject.tag == "Object")
            {
                fromObjectsBottomInventoryManager.AddObject(ingredientName, ingredientSprite);//canviar per funcio addobject del inventory Manager
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("No hi ha cap tag Ingredient o Objecte");
            }
        }
        else
        {
            Debug.LogError("bottomInventoryManager no est� assignat.");
        }
    }
}
