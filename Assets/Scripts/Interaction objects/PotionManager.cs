using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotionManager : MonoBehaviour
{
    int contadorIngredients = 0;
    public GameObject PotionCanvas;
    public GameObject BottomIngredientCanvas;
    public GameObject CanvasHints;
    public GameObject InventoriCanvas;
    public GameObject CanvasBotons;

    public CameraSwitcher cameraSwitcher;
    public AudioSource potionCanvasSound;

    void Start()
    {
        PotionCanvas.SetActive(false);
    }
    public void IngredientPotion()
    {
        contadorIngredients++;
        Debug.Log("Ingredientes en el caldero: " + contadorIngredients);
        if ((contadorIngredients == 3 && SceneManager.GetActiveScene().name == "Tutorial") ||
            (contadorIngredients == 4 && SceneManager.GetActiveScene().name == "Nivell 1"))
        {
            Debug.Log("poción completada");
            PotionCanvas.SetActive(true);
            potionCanvasSound.Play();
            BottomIngredientCanvas.SetActive(false);
            CanvasHints.SetActive(false);
            InventoriCanvas.SetActive(false);
            CanvasBotons.SetActive(false);
            cameraSwitcher.PauseStaticMusic();
        }
    }
}
