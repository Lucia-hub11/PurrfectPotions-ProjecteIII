using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    int contadorIngredients = 0;
    public GameObject PotionCanvas;
    //public GameObject etc;

    void Start()
    {
        PotionCanvas.SetActive(false);
    }
    public void IngredientPotion()
    {
        contadorIngredients++;
        Debug.Log("Ingredientes en el caldero: " + contadorIngredients);
        if(contadorIngredients == 3)
        {
            PotionCanvas.SetActive(true);
            //etc.SetActive(false);
            Debug.Log("hola la poción ya está hecha que pasa??");
        }
    }
}
