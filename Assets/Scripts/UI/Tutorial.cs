using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI pista;
    public Image pistaSprite;
   
    private float tempsApareixer = 5f;
    private float tempsDesapareixer;

    private int tutorialStep = 0;

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
        "Començem la teva primera lliçó!",    //0
        "Mou-te utilitzant les tecles WASD per desplaçar-te.", //1
        "Prem 'I' o fes clic al botó per obrir l'inventari i veure la recepta de la poció.", //2
        "Surt de casa per buscar els ingredients que necessites.", //3
        "Has trobat un ingredient! Mira'l a l'inventari.", //4
        "Amb el pou podem aconseguir aigua, però falta la galleda...", //5
        "Has trobat la galleda! Els objectes també es guarden a l'inventari.", //6
        "Per fer servir un objecte és tan fàcil com arrossegar-ho des de la barra inferior.", //7
        "Prova-ho amb la galleda. Arrossega-la cap al pou.", //8
        "Tens tots els ingredients! Torna cap a casa.", //9
        "Arrossega els ingredients al calder per completar la poció." //10
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
        if (pista.enabled && (Time.time >= tempsDesapareixer))
        {
            pista.enabled = false;
            pistaSprite.enabled = false;

            if (tutorialStep == 0 || tutorialStep == 1 || tutorialStep == 2)
            {
                tutorialStep++; //1, 2 i 3
                ShowCurrentHint();
            }
            if () //ha encontrado un ingrediente
            {

            }
            if () //se ha acercado al pozo SIN la galleda
            {

            }
            if () //ha encontrado el cubo
            {

            }
            if () //se ha acercado al pozo CON la galleda
            {
                //pistas 7 i 8
            }
            if () //todos los ingredientes
            {

            }
            if () //vuelve a entrar en casa
            {

            }
        }
    }
}
