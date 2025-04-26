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
        /*// per bloquejar input i moviment per fer "pause" pel darrere del minijoc i que no es pugui moure
        var player = GameObject.FindGameObjectWithTag("Player");
        var ic = player.GetComponent<InputController>();
        var pc = player.GetComponent<PlayerController>();
        if (ic != null) ic.enabled = false;
        if (pc != null) pc.enabled = false;*/

        // activar joc
        memory.enabled = true;
        GameObject cardsController = GameObject.Find("CardsController");
        ComportamentFiches fichesScript = cardsController.GetComponent<ComportamentFiches>();
        fichesScript.mushroom = ingredient;
        StartCoroutine(fichesScript.ShowCards());
        
    }
}
