using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField]
    private string ingredientName;

    private InventoryManager inventoryManager;

    private InputController _inputController;
    // Start is called before the first frame update
    void Start()
    {
        _inputController = GetComponent<InputController>();
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventoryManager.AddIngredient(ingredientName);
            Destroy(gameObject);
        }
        
    }

}
