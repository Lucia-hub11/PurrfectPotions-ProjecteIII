using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryWindow; //saber qu� activa, asignar al Inspector
    private bool inventoryOpen = false;
    public IngredientSlot[] ingredientSlot;

    private InputController _inputController;

    void Start()
    {
        // Buscar el Player i el seu InputController
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _inputController = player.GetComponent<InputController>();
        
        // Assegurar-se que l'inventari comen�a tancat (tot i que ja est� tancat per defecte en teoria)
        if (InventoryWindow != null)
        {
            InventoryWindow.SetActive(false);
        }
    }

    void Update()
    {
        if (_inputController.Inventory && !inventoryOpen)
        {
            Time.timeScale = 0; //per pausar el joc quan s'obre l'inventari (si es posena animacions al inventari aixo pot causar problemes!)
            Debug.Log("obrir inventari");
            InventoryWindow.SetActive(true);
            inventoryOpen = true;
        }
        else if (_inputController.Inventory && inventoryOpen)
        {
            Time.timeScale = 1; //per pausar el joc quan s'obre l'inventari
            InventoryWindow.SetActive(false);
            inventoryOpen = false;
        }
    }

    public void AddIngredient (string ingredientName, Sprite ingredientSprite)
    {
        for (int i = 0; i < ingredientSlot.Length; i++)
        {
            if (ingredientSlot[i].isFull==false)
            {
                ingredientSlot[i].AddIngredientSprite(ingredientName, ingredientSprite);
                return;
            }
        }
        
        //Debug.Log("ingredientName = " + ingredientName);

    }
}
