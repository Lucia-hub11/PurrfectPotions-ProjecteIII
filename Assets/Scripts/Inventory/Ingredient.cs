using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public StartMemoryGame memoryGame;
    public CrowTalk crowTalk;
    public Tutorial tutorial;
    public GameObject Code;
    public StartClimbers climbersGame;

    bool crowDimond = false;
    bool tearObtained = false;
    bool galledaPou = false;
    public static int primerIngredient = 0;

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
            if (isInRange && tearObtained==false)
            {
                //Debug.Log("player esta al range!");
                interactText.SetActive(true);
            }
            else if(isInRange && tearObtained==true)//per no interactuar amb el trevol un cop ja s'ha agafat la llàgrima
            {
                interactText.SetActive(false);
            }
            else //cada model t� un text per separat pq si no es barallen
            {
                interactText.SetActive(false);
            }
        } // simplificat seria aixi if (interactText) interactText.SetActive(isInRange);

        if (isInRange && ingredientName=="Aigua")
        {
            if (galledaPou == false)
            {
                Debug.Log("galleda bien");
                tutorial.tutorialStep = 5;
                tutorial.ShowCurrentHint();
            }
        }

        if (isInRange && _inputController.Interact)
        {
            if(ingredientName=="Invisible Mushroom")
            {
                memoryGame.JocMemory(this);
                //Destroy(interactText);
                interactText.SetActive(false);
            }
            else if (ingredientName == "Magic Flower")
            {
                climbersGame.JocClimbers(this);
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
            else if (tearObtained==true){
                
                interactText.SetActive(false);
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
        // Comprobamos referencias
        if (inventoryManager == null || fromIngredientsBottomInventoryManager == null || fromObjectsBottomInventoryManager == null)
        {
            Debug.LogError("[Ingredient] Inventario no asignado en Inspector");
            return;
        }

        if (gameObject.tag == "Ingredient")
        {
            if (primerIngredient==0)
            {
                tutorial.tutorialStep = 4;
                tutorial.ShowCurrentHint();
            }
            else if (primerIngredient==2)
            {
                tutorial.tutorialStep = 9;
                tutorial.ShowCurrentHint();
                //mandar mensaje a ExteriorAInterior
            }

            if(ingredientName== "Crow Feather")//el mateix però sense destruir-lo
            {
                inventoryManager.AddIngredient(ingredientName, ingredientSprite);
                fromIngredientsBottomInventoryManager.AddIngredient(ingredientName, ingredientSprite);
                interactText.SetActive(false);
                crowDimond = true;
            }
            else if (ingredientName == "Aigua")
            {
                inventoryManager.AddIngredient(ingredientName, ingredientSprite);
                fromIngredientsBottomInventoryManager.AddIngredient(ingredientName, ingredientSprite);
                interactText.SetActive(false);
                galledaPou = true;
            }
            else if (ingredientName == "Tear")//el mateix però sense destruir-lo
            {
                inventoryManager.AddIngredient(ingredientName, ingredientSprite);
                fromIngredientsBottomInventoryManager.AddIngredient(ingredientName, ingredientSprite);
                interactText.SetActive(false);
                tearObtained=true;
            }
            else
            {
                inventoryManager.AddIngredient(ingredientName, ingredientSprite);
                fromIngredientsBottomInventoryManager.AddIngredient(ingredientName, ingredientSprite);
                Destroy(gameObject);
                interactText.SetActive(false);
            }

            primerIngredient++;
            Debug.Log(primerIngredient);
        }
        else if (gameObject.tag == "Object")
        {
            inventoryManager.AddObject(ingredientName, ingredientSprite);//canviar per funcio addobject del inventory Manager
            fromObjectsBottomInventoryManager.AddObject(ingredientName, ingredientSprite);
            Destroy(gameObject);
            interactText.SetActive(false);
            if(ingredientName=="Galleda")
            {
                //Debug.Log(ingredientName);
                //Activar tutorial de como puedes usar los objetos
                galledaPou = true;
                //Debug.Log(galledaPou);
                tutorial.tutorialStep = 6;
                tutorial.ShowCurrentHint();
            }
        }
        else
        {
            Debug.Log("No hi ha cap tag Ingredient o Objecte");
        }

    }
}
