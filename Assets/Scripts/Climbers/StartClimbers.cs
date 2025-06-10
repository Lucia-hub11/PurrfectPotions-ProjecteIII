using System;
using UnityEngine;
using UnityEngine.UI;

public class StartClimbers : MonoBehaviour
{
    [SerializeField] private Canvas climbersCanvas;       // El Canvas que contiene ClimbersGame
    [SerializeField] private ClimbersGame climbersLogic;  // El script que hace el raycast

    private Ingredient currentIngredient;

    private void Awake()
    {
        // Auto-asignación si no lo pones en el Inspector
        if (climbersCanvas == null)
            climbersCanvas = GetComponent<Canvas>();
        if (climbersLogic == null)
            climbersLogic = GetComponent<ClimbersGame>();

        // ...o en hijos, por si tenías la lógica en un child
        if (climbersCanvas == null)
            climbersCanvas = GetComponentInChildren<Canvas>();
        if (climbersLogic == null)
            climbersLogic = GetComponentInChildren<ClimbersGame>();
    }

    private void Start()
    {
        if (climbersCanvas != null)
            climbersCanvas.enabled = false;
    }

    public void JocClimbers(Ingredient ingredient)
    {
        currentIngredient = ingredient;

        // COMPROBACIONES  
        if (climbersCanvas == null)
        {
            Debug.LogError("[StartClimbers] climbersCanvas NO está asignado.");
            return;
        }
        if (climbersLogic == null)
        {
            Debug.LogError("[StartClimbers] climbersLogic NO está asignado.");
            return;
        }

        // 1) Pausar el juego
        Time.timeScale = 0f;
        // 2) Mostrar UI
        climbersCanvas.enabled = true;

        // 3) Desactivar controles 3D
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var ic = player.GetComponent<InputController>();
            if (ic != null) ic.enabled = false;
            var pc = player.GetComponent<PlayerController>();
            if (pc != null) pc.enabled = false;
        }

        // 4) Suscribir y arrancar minijuego
        climbersLogic.onWin += HandleWin;
        climbersLogic.onQuit += HandleQuit;
        climbersLogic.StartMinigame();
    }

    private void HandleWin()
    {
        // Al ganar, colecta el ingrediente
        currentIngredient.CollectIngredient();
        EndClimbers();
    }

    private void HandleQuit()
    {
        EndClimbers();
    }

    private void EndClimbers()
    {
        //Restaurar tiempo y ocultar UI
        Time.timeScale = 1f;
        climbersCanvas.enabled = false;

        //Reactivar controles del jugador
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var ic = player.GetComponent<InputController>();
            if (ic != null) ic.enabled = true;
            var pc = player.GetComponent<PlayerController>();
            if (pc != null) pc.enabled = true;
        }

        //Desuscribir eventos y resetear minijuego
        climbersLogic.onWin -= HandleWin;
        climbersLogic.onQuit -= HandleQuit;
        climbersLogic.ResetMinigame();
    }
}
