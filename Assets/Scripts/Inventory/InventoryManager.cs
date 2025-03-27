using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryWindow; //saber què activa, asignar al Inspector
    private bool inventoryOpen = false;

    private InputController _inputController;

    void Start()
    {
        // Buscar el Player i el seu InputController
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _inputController = player.GetComponent<InputController>();
        
        // Assegurar-se que l'inventari comença tancat (tot i que ja està tancat per defecte en teoria)
        if (InventoryWindow != null)
        {
            InventoryWindow.SetActive(false);
        }
    }

    void Update()
    {
        if (_inputController.Inventory && !inventoryOpen)
        {
            Debug.Log("obrir inventari");
            InventoryWindow.SetActive(true);
            inventoryOpen = true;
        }
        else if (_inputController.Inventory && inventoryOpen)
        {
            InventoryWindow.SetActive(false);
            inventoryOpen = false;
        }
    }

    public void AddIngredient (string ingredientName)
    {
        Debug.Log("ingredientName = " + ingredientName);
    }
}
