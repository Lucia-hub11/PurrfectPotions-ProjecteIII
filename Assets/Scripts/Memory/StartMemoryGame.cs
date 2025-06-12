using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartMemoryGame : MonoBehaviour
{
    public Canvas memory;
    public float time;
    public Image Fill;
    public float Max;
    public GameObject Missatge;

    private bool timerRunning = false;

    private void Start()
    {
        memory.enabled = false;
        time=Max;
        if(Fill!=null)
        {
            Debug.Log("fill NO es null");
            Fill.fillAmount=1f;
            Debug.Log("Fill: " + Fill.fillAmount);
        }
    }

    IEnumerator ShowMessageForSeconds(float seconds)
    {
        Missatge.SetActive(true);
        yield return new WaitForSeconds(seconds);
        Missatge.SetActive(false);
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
        StartCoroutine(ShowMessageForSeconds(2f));
        StartTimer();
        GameObject cardsController = GameObject.Find("CardsController");
        ComportamentFiches fichesScript = cardsController.GetComponent<ComportamentFiches>();
        fichesScript.mushroom = ingredient;
        StartCoroutine(fichesScript.ShowCards());
    }

    void StartTimer()
    {
        time = Max;
        Fill.fillAmount = 1f;
        timerRunning = true;
    }

    void Update()
    {
        if(!timerRunning)
        {
            return;
        }
        if(time>0f)
        {
            time -= Time.deltaTime;
            float normalized = Mathf.Clamp01(time/Max);
            Fill.fillAmount = normalized;
            Debug.Log("Fill: " + Fill.fillAmount);
        }
        else
        {
            Fill.fillAmount = 0f;
        }
        //time -= Time.deltaTime;
        //Fill.fillAmount = time / Max;

        //if(time<0)
        //time =0;
    }
}
