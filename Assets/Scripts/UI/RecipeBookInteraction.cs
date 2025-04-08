using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBookInteraction : MonoBehaviour
{
    // Referencia al canvas que contiene la receta
    public GameObject recipeCanvas;

    // Bandera para saber si el jugador está dentro del área de interacción
    private bool canInteract = false;

    // Bandera para saber si la receta está actualmente abierta
    private bool isRecipeOpen = false;

    // Se ejecuta al iniciar
    private void Start()
    {
        // Asegurarse de que el canvas esté cerrado al inicio
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
            // Aquí podrías mostrar un mensaje en la UI, por ejemplo "Presiona E para interactuar"
        }
    }

    // Se activa cuando otro collider sale del trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            // Si el jugador sale mientras la receta está abierta, puedes cerrarla automáticamente
            if (isRecipeOpen)
            {
                ToggleRecipe();
            }
        }
    }

    // Se actualiza cada frame
    private void Update()
    {
        // Verifica si el jugador está en zona de interacción y si se presiona la tecla E
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            ToggleRecipe();
        }
    }

    // Método para alternar la visualización de la receta
    public void ToggleRecipe()
    {
        // Cambia el estado de la receta
        isRecipeOpen = !isRecipeOpen;
        // Activa o desactiva el canvas
        if (recipeCanvas != null)
            recipeCanvas.SetActive(isRecipeOpen);
    }

    // Método que puedes asignar al botón de cerrar la receta en el Canvas
    public void CloseRecipe()
    {
        isRecipeOpen = false;
        if (recipeCanvas != null)
            recipeCanvas.SetActive(false);
    }
}
