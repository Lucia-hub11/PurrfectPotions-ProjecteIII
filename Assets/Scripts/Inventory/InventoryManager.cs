using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryWindow; //saber què activa, asignar al Inspector
    private bool inventoryOpen = false;
    public IngredientSlot[] ingredientSlot;
    public ObjectSlot[] objectSlot;

    public AskForHint hintSystem;

    private InputController _inputController;

    public GameObject InteractTextCanvas;

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
            Time.timeScale = 0; //per pausar el joc quan s'obre l'inventari (si es posena animacions al inventari aixo pot causar problemes!)
            Debug.Log("obrir inventari");
            InventoryWindow.SetActive(true);
            inventoryOpen = true;
            InteractTextCanvas.SetActive(false);//desactivar el text de "Clica E per interactuar", sinó quedava per sobre

        }
        else if (_inputController.Inventory && inventoryOpen)
        {
            Time.timeScale = 1; //per pausar el joc quan s'obre l'inventari
            InventoryWindow.SetActive(false);
            inventoryOpen = false;
            InteractTextCanvas.SetActive(true);//tornar a activar el canvas on hi ha els textos d'interacció
        }
    }

    public void AddIngredient (string ingredientName, Sprite ingredientSprite)
    {
        for (int i = 0; i < ingredientSlot.Length; i++)
        {
            if (ingredientSlot[i].isFull==false)
            {
                ingredientSlot[i].AddIngredientSprite(ingredientName, ingredientSprite);
                Debug.Log("ingredientName = " + ingredientName);
                //función que pase el nombre de ingredientName supongo que por string a AskForHint a la función AssignHint
               
                if (hintSystem != null)
                {
                    hintSystem.AddCollectedIngredient(ingredientName);
                }
                
                return;
            }
        }

    }
    
    public void AddObject(string ingredientName, Sprite ingredientSprite)
    {
        for (int i = 0; i < objectSlot.Length; i++)
        {
            if (objectSlot[i].isFull == false)
            {
                objectSlot[i].AddObjectSprite(ingredientName, ingredientSprite);
                Debug.Log("ingredientName = " + ingredientName);
                //función que pase el nombre de ingredientName supongo que por string a AskForHint
               
                if (hintSystem != null)
                {
                    hintSystem.AddCollectedIngredient(ingredientName);
                }
                
                return;
            }
        }

    }//FUNCIÓ PER FER EL MATEIXO PERO AMB ADD OBJECT

    public void ClearObject(string objectName)
    {
        foreach (var slot in objectSlot)
        {
            if (slot.objectName == objectName)
            {
                slot.ClearObject();
            }
        }
    }
    public void ClearIngredient(string ingredientName)
    {
        foreach (var slot in ingredientSlot)
        {
            if (slot.ingredientName == ingredientName)
            {
                slot.ClearIngredient();
            }
        }
    }
}
