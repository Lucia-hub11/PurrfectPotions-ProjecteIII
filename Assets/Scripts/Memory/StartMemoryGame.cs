using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMemoryGame : MonoBehaviour
{
    public Canvas memory;
    private void Start()
    {
        memory.enabled = false;
    }

    public void JocMemory(Ingredient ingredient)
    {
        memory.enabled = true;
        GameObject cardsController = GameObject.Find("CardsController");
        ComportamentFiches fichesScript = cardsController.GetComponent<ComportamentFiches>();
        fichesScript.mushroom = ingredient;
        StartCoroutine(fichesScript.ShowCards());
        
    }
}
