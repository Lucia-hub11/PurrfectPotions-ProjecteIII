using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AskForHint : MonoBehaviour
{
    public TextMeshProUGUI pista;
    int contador = 0;

    //cal augmentar el contador++ segons els ingredients aconseguits a l'inventari. Esperar a que la Nora aconsegueixi guardar llista d'ingredients aconseguits a l'inventari.
    //De moment contador++ es suma cada cop que es pren el botó per fer la prova.

    public string[] Hints = new string[] { "Pista 1", "Pista 2", "Pista 3", "Pista 4" };

    public void ButtonPressed()
    {
        pista.text = Hints[contador];
        contador++;
    }

    // Start is called before the first frame update
    void Start()
    {
        pista.text = contador + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
