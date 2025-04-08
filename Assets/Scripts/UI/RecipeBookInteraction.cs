using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBookInteraction : MonoBehaviour
{
    // Referencia al canvas que contiene la receta
    public GameObject recipeCanvas;

    // Bandera para saber si el jugador est� dentro del �rea de interacci�n
    private bool canInteract = false;

    // Bandera para saber si la receta est� actualmente abierta
    private bool isRecipeOpen = false;

    // Se ejecuta al iniciar
    private void Start()
    {
        // Asegurarse de que el canvas est� cerrado al inicio
        if (recipeCanvas != null)
            recipeCanvas.SetActive(false);
    }

    // Se activa cuando otro collider entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que ingresa es el jugador
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            // Aqu� podr�as mostrar un mensaje en la UI, por ejemplo "Presiona E para interactuar"
        }
    }

    // Se activa cuando otro collider sale del trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            // Si el jugador sale mientras la receta est� abierta, puedes cerrarla autom�ticamente
            if (isRecipeOpen)
            {
                ToggleRecipe();
            }
        }
    }

    // Se actualiza cada frame
    private void Update()
    {
        // Verifica si el jugador est� en zona de interacci�n y si se presiona la tecla E
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            ToggleRecipe();
        }
    }

    // M�todo para alternar la visualizaci�n de la receta
    public void ToggleRecipe()
    {
        // Cambia el estado de la receta
        isRecipeOpen = !isRecipeOpen;
        // Activa o desactiva el canvas
        if (recipeCanvas != null)
            recipeCanvas.SetActive(isRecipeOpen);
    }

    // M�todo que puedes asignar al bot�n de cerrar la receta en el Canvas
    public void CloseRecipe()
    {
        isRecipeOpen = false;
        if (recipeCanvas != null)
            recipeCanvas.SetActive(false);
    }
}
