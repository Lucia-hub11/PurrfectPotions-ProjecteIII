using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI pista;
    public Image pistaSprite;
   
    private float tempsApareixer = 5f;
    private float tempsDesapareixer;

    public int tutorialStep = 0;

    public void Start()
    {
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            this.enabled = false;
            return;
        }
          ShowCurrentHint();

    }

    public List<string> tutorialTexts = new List<string>()
    {
        "Comen�em la teva primera lli��!",    //0
        "Mou-te utilitzant les tecles WASD per despla�ar-te.", //1
        "Prem 'I' o fes clic al bot� per obrir l'inventari i veure la recepta de la poci�.", //2
        "Surt de casa per buscar els ingredients que necessites.", //3
        "Has trobat un ingredient! Mira'l a l'inventari.", //4
        "Amb el pou podem aconseguir aigua, per� falta la galleda...", //5
        "Has trobat la galleda! Els objectes es guarden a l'inventari.", //6
        "Per fer servir un objecte �s tan f�cil com arrossegar-ho des de la barra inferior.", //7
        "Prova-ho amb la galleda. Arrossega-la cap al pou.", //8
        "Tens tots els ingredients! Torna cap a casa.", //9
        "Arrossega els ingredients al calder per completar la poci�." //10
    };

    public void ShowCurrentHint()
    {
        if (tutorialStep < tutorialTexts.Count)
        {
            pista.text = tutorialTexts[tutorialStep];
            pista.enabled = true;
            pistaSprite.enabled = true;
            tempsDesapareixer = Time.time + tempsApareixer;
        }
    }

    
    void Update()
    {
        //Para las pistas que se reproducen automaticamente
        if (pista.enabled && (Time.time >= tempsDesapareixer))
        {
            pista.enabled = false;
            pistaSprite.enabled = false;

            if (tutorialStep == 0 || tutorialStep == 1 || tutorialStep == 2 || tutorialStep == 6 || tutorialStep == 7)
            {
                tutorialStep++; //1, 2, 3, 7 i 8
                ShowCurrentHint();
            }
        }
    }
}
