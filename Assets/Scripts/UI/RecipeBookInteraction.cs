using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBookInteraction : MonoBehaviour
{
    public GameObject recipeCanvas;
    public GameObject pressEText;

    private bool canInteract = false;
    private bool isRecipeOpen = false;

    public AudioSource recipeAudioSource;

    private void Start()
    {
        // Asegurarse de que el canvas esté cerrado al inicio
        if (recipeCanvas != null)
            recipeCanvas.SetActive(false);

        // Asegurarse de que el texto de interacción esté oculto al inicio
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
                Debug.LogWarning("[RecipeBook] pressEText no está asignado en el Inspector");
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

            // Si el jugador sale mientras la receta está abierta, cerrar la receta
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

            // Al abrir o cerrar la receta, ocultar el texto de interacción
            if (pressEText != null)
                pressEText.SetActive(false);
        }
    }

    
    private void ToggleRecipe()
    {
        isRecipeOpen = !isRecipeOpen;
        if (recipeCanvas != null)
            recipeCanvas.SetActive(isRecipeOpen);

        if (isRecipeOpen && recipeAudioSource != null)
        {
            recipeAudioSource.Play();
        }
    }

    public void CloseRecipeWithButton()
    {
        if(isRecipeOpen)
        {
            ToggleRecipe();
            if(pressEText!=null)
            {
                pressEText.SetActive(false);
            }
        }
    }
}
