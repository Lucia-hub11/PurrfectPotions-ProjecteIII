using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] 
    private string ingredientName;

    public Sprite ingredientSprite;

    public float ingredientRange = 4;
    public GameObject interactText;

    private InventoryManager inventoryManager;
    private BottomInventoryManager bottomInventoryManager;
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
        GameObject inventoryBottom = GameObject.Find("BottomSlotsCanvas");

        inventoryManager = inventoryObject.GetComponent<InventoryManager>();

        if (inventoryObject != null)
        {
            bottomInventoryManager = inventoryBottom.GetComponent<BottomInventoryManager>();
        }
        else
        {
            Debug.LogError("No s'ha trobat 'BottomSlotsCanvas'.");
        }

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
                Debug.Log("player esta al range!");
                interactText.SetActive(true);
            }
            else //aqui hauria de fer que quan surti del range sigui fals, no sempre que fora sigui fals pq si no es barallen
            {
                interactText.SetActive(false);
            }
        } // simplificat seria aixi if (interactText) interactText.SetActive(isInRange);

        if (isInRange && _inputController.Interact)
        {
            CollectIngredient();
            interactText.SetActive(false);
        } 
    }
    private void CollectIngredient()
    {
        if (inventoryManager != null)
        {
            inventoryManager.AddIngredient(ingredientName, ingredientSprite);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("InventoryManager no està assignat.");
        }

        if (bottomInventoryManager != null)
        {
            bottomInventoryManager.AddIngredient(ingredientName, ingredientSprite);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("bottomInventoryManager no està assignat.");
        }
    }
}
