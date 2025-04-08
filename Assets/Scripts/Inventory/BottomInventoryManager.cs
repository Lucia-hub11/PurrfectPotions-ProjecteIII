using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomInventoryManager : MonoBehaviour
{
    public GameObject InventoryWindow; //crec que aixo es podrà treure
    
    public IngredientSlot[] ingredientSlot;

    private InputController _inputController;

    void Start()
    {
        // Buscar el Player i el seu InputController
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _inputController = player.GetComponent<InputController>();
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
