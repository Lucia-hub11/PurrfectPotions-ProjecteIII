using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartClimbers : MonoBehaviour
{

    [SerializeField] private Canvas climbersCanvas;
    [SerializeField] private ClimbersGame climbersLogic;

    private Ingredient currentIngredient;

    private void Awake()
    {
        if (climbersCanvas == null)
            climbersCanvas = GetComponent<Canvas>();
        if (climbersLogic == null)
            climbersLogic = GetComponent<ClimbersGame>();
    }

    private void Start()
    {
        climbersCanvas.enabled = false;
    }

    public void JocClimbers(Ingredient ingredient)
    {
        currentIngredient = ingredient;
        Time.timeScale = 0f;
        climbersCanvas.enabled = true;

        // Desactiva controles 3D
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<InputController>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;

        // Eventos de finishing o quit
        climbersLogic.onWin += HandleWin;
        climbersLogic.onQuit += HandleQuit;
        climbersLogic.StartMinigame();
    }

    private void HandleWin()
    {
        currentIngredient.Collect();  // le da el ingrediente
        EndClimbers();
    }

    private void HandleQuit()
    {
        EndClimbers();
    }

    private void EndClimbers()
    {
        Time.timeScale = 1f;
        climbersCanvas.enabled = false;

        // Reactiva controles 3D
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<InputController>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;

        // Limpiar suscripciones y reset
        climbersLogic.onWin -= HandleWin;
        climbersLogic.onQuit -= HandleQuit;
        climbersLogic.ResetMinigame();
    }
}
