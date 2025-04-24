using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBookInteraction : MonoBehaviour
{
    // Referencia al canvas que contiene la receta
    public GameObject recipeCanvas;

    // Referencia al texto de interacci�n "Press E to interact"
    public GameObject pressEText;

    // Bandera para saber si el jugador est� dentro del �rea de interacci�n
    private bool canInteract = false;

    // Bandera para saber si la receta est� actualmente abierta
    private bool isRecipeOpen = false;

    private void Start()
    {
        // Asegurarse de que el canvas est� cerrado al inicio
        if (recipeCanvas != null)
            recipeCanvas.SetActive(false);

        // Asegurarse de que el texto de interacci�n est� oculto al inicio
        if (pressEText != null)
            pressEText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[RecipeBook] OnTriggerEnter con {other.name} (tag={other.tag})");
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            if (pressEText != null && !isRecipeOpen)
                pressEText.SetActive(true);
            else if (pressEText == null)
                Debug.LogWarning("[RecipeBook] pressEText no est� asignado en el Inspector");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;

            // Ocultar el texto cuando el jugador se aleja
            if (pressEText != null)
                pressEText.SetActive(false);

            // Si el jugador sale mientras la receta est� abierta, cerrar la receta
            if (isRecipeOpen)
            {
                ToggleRecipe();
            }
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            ToggleRecipe();

            // Al abrir o cerrar la receta, ocultar el texto de interacci�n
            if (pressEText != null)
                pressEText.SetActive(false);
        }
    }

    
    private void ToggleRecipe()
    {
        isRecipeOpen = !isRecipeOpen;
        if (recipeCanvas != null)
            recipeCanvas.SetActive(isRecipeOpen);
    }
}
