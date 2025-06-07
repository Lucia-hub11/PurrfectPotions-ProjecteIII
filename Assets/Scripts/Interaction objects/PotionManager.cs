using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotionManager : MonoBehaviour
{
    int contadorIngredients = 0;
   // public GameObject PotionCanvas;
 //   public GameObject BottomIngredientCanvas;
   // public GameObject CanvasHints;
 //   public GameObject InventoriCanvas;
   // public GameObject CanvasBotons;

  //  void Start()
    //{
  //      PotionCanvas.SetActive(false);
    //}
    public void IngredientPotion()
    {
        contadorIngredients++;
        Debug.Log("Ingredientes en el caldero: " + contadorIngredients);
        if(contadorIngredients == 1)
        {
     //       PotionCanvas.SetActive(true);
       //     BottomIngredientCanvas.SetActive(false);
         //   CanvasHints.SetActive(false);
           // InventoriCanvas.SetActive(false);
       //     CanvasBotons.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
