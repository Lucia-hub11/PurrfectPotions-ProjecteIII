using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AskForHint : MonoBehaviour
{
    public TextMeshProUGUI pista;
    public Image pistaSprite;
    // int contador = 0;

    //cal augmentar el contador++ segons els ingredients aconseguits a l'inventari. Esperar a que la Nora aconsegueixi guardar llista d'ingredients aconseguits a l'inventari.
    //De moment contador++ es suma cada cop que es pren el bot� per fer la prova.

    // public string[] Hints = new string[] {};
    private float tempsApareixer = 5f;
    private float tempsDesapareixer;

    
    private Dictionary<string, string> hintByIngredient = new Dictionary<string, string>()
    {
        {"Diamond", "Els cristalls del bosc s�n tan bonics! Els has vist b�?"},
        {"Invisible Mushroom", "El laberint: fosc, humit, tranquil... Ideal pel cultiu de fongs!"},
        {"Tear", "Quan estic frustrat passejo pel camp de flors. T'ho recomano."}
    };


    private List<string> collectedIngredients = new List<string>();

    public string finalHint = "Sembla que ja tens tot el que necessites per la poci�. Bona feina! Torna cap a casa i cuinem-la.";

    public AudioSource buttonSound;

    public void AddCollectedIngredient(string ingredientName)
    {
        if (!collectedIngredients.Contains(ingredientName))
        {
            collectedIngredients.Add(ingredientName);
        }
    }

    //funci�n para asignar n�mero de pista seg�n nombre
    // public void AssignHint(string IngredientName)
    // {
        //recoger el nombde de IngredientName y asignar numero de pista correspondiente.
    // }

    public void ButtonPressed()
    {
        if (buttonSound != null)
        {
            buttonSound.Play();
        }
        //en vez de contador deber�a ser switch cases?
        //Empezar si no tiene ningun item elegir random entre todas las pistas menos la ultima (son cuatro en total van de 0 a 3, la numero 3 entonces no se muestra)
        //Siguientes cases ser�a las opciones de ingredientes que pueden tener, como son tres opciones no hay demasiadas combinaciones pero si fueran m�s ser�a complicado.
        // Tal vez vaya mejor con un if. Poner un contador o algo as� y seg�n el item que haya conseguido cambia el n�mero, o directamente mandamos el nombre del ingrediente al script y hacemos if ingredientName == al que sea, entonces random entre estos.
        //Lo ideal ser�a enlacar directamente el nombre de cada ingrediente con el n�mero de pista al que corresponde y hacer elegir random entre las pistas MENOS la de ingredientName. Si, esa es la mejor opci�n.
        
        // if (contador<Hints.Length)
        // {
            pistaSprite.enabled = true;
            pista.enabled = true;
            tempsDesapareixer = Time.time + tempsApareixer;
            //pista.text = Hints[contador];
            //contador++;

            //contador tiene que depender del objeto encontrado, no de la pista.
            //recives pistas aleatorias excepto las que pertenezcan a items que ya has conseguido.
            //No es contador entonces, es vincular un numero de pista para cada objeto en espec�fico.
            // Nivel 1: Diamond(0), Bolet (1), Flor m�gica + ll�grima (2), tornar a casa no debe incluirse en el random, es al final.
        // }
        // else
        // {
        //     pista.text = Hints[3];
        // }

        List<string> remainingIngredients = new List<string>();

        foreach (var kvp in hintByIngredient)
        {
            if (!collectedIngredients.Contains(kvp.Key))
            {
                 remainingIngredients.Add(kvp.Key);
            }
        }

        if (remainingIngredients.Count > 0)
        {
            string randomIngredient = remainingIngredients[Random.Range(0, remainingIngredients.Count)];
            pista.text = hintByIngredient[randomIngredient];
        }
        else
        {
            pista.text = finalHint;
        }
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    pista.text = contador + "";
    //}

    // Update is called once per frame
    void Update()
    {
        if (pista.enabled && (Time.time >= tempsDesapareixer))
        {
            pista.enabled = false;
            pistaSprite.enabled = false;
        }
    }
}


// Pistas para el tutorial: (seguramente necesite un script diferente pero bueno)
// Com aconseguirem aigua si al pou falta la galleda?
// El preu de les pomes �s molt alt �ltimament, no creixen als arbres! Ei, espera un moment...
// Recorda que el menjar el guardem al rebost, fora de la casa.
// Sembla que ja tens tot el que necessites per la poci�. Bona feina! Torna cap a casa i cuinem-la.
