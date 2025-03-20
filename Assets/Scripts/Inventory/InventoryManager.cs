using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryWindow; //saber què activa
    private bool inventoryOpen;

    private InputController _inputController;

    // Start is called before the first frame update
    void Start()
    {
        _inputController = GetComponent<InputController>();

    }

    // Update is called once per frame
    void Update()
    {

        /*if (_inputController.Inventory)
        {
            Debug.Log("Tecla I detectada. Intentant canviar estat d'inventari.");
            inventoryOpen = !inventoryOpen; // Inverteix l'estat de l'inventari
            InventoryWindow.SetActive(inventoryOpen); // Activa o desactiva la finestra
        }*/
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
