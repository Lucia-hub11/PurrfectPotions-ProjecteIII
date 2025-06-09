using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartClimbers : MonoBehaviour
{
    public Canvas climbersCanvas;
    public ClimbersGame climbersGame;

    private Ingredient currentIngredient;
    private void Start()
    {
        climbersCanvas.enabled = false;
    }

    public void JocClimbers(Ingredient ingredient)
    {
        currentIngredient = ingredient;

        // 1) Pausar el juego principal
        Time.timeScale = 0f;
        // 2) Mostrar Canvas y cursor UI
        climbersCanvas.enabled = true;
        climbersGame.StartMinigame();

        // 3) Opcional: deshabilitar controles de jugador por si acaso
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<InputController>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;

        // 4) Comunicarle al ClimbersGame cuál es el ingrediente a dar
        climbersGame.onWin += HandleWin;
        climbersGame.onQuit += HandleQuit;
    }

    private void HandleWin()
    {
        // Al ganar, añade ingrediente
        currentIngredient.CollectIngredient();

        EndClimbers();
    }

    private void HandleQuit()
    {
        // Si salta sin terminar
        EndClimbers();
    }

    private void EndClimbers()
    {
        // 1) Restaurar tiempo y controles
        Time.timeScale = 1f;
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<InputController>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;

        // 2) Ocultar Canvas y resetear minijuego
        climbersGame.ResetMinigame();
        climbersCanvas.enabled = false;

        // 3) Limpiar callbacks
        climbersGame.onWin -= HandleWin;
        climbersGame.onQuit -= HandleQuit;
    }

}
