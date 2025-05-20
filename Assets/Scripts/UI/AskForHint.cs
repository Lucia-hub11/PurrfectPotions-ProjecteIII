using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AskForHint : MonoBehaviour
{
    public TextMeshProUGUI pista;
    public Image pistaSprite;
    int contador = 0;

    //cal augmentar el contador++ segons els ingredients aconseguits a l'inventari. Esperar a que la Nora aconsegueixi guardar llista d'ingredients aconseguits a l'inventari.
    //De moment contador++ es suma cada cop que es pren el botó per fer la prova.

    public string[] Hints = new string[] { "", "", "", "" };
    private float tempsApareixer = 5f;
    private float tempsDesapareixer;

    public void ButtonPressed()
    {
        if (contador<Hints.Length)
        {
            pistaSprite.enabled = true;
            pista.enabled = true;
            tempsDesapareixer = Time.time + tempsApareixer;
            pista.text = Hints[contador];
            contador++;
        }
        else
        {
            pista.text = Hints[3];
        }

    }

    //// Start is called before the first frame update
    //void Start()
    //{
    //    pista.text = contador + "";
    //}

    //// Update is called once per frame
    void Update()
    {
        if (pista.enabled && (Time.time >= tempsDesapareixer))
        {
            pista.enabled = false;
            pistaSprite.enabled = false;
        }
    }
}
