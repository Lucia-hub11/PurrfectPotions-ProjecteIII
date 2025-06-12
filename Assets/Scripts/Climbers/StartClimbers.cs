using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartClimbers : MonoBehaviour
{
    [SerializeField] private Canvas climbersCanvas;       // El Canvas que contiene ClimbersGame
    [SerializeField] private ClimbersGame climbersLogic;  // El script que hace el raycast

    public Ingredient currentIngredient;

    public GameObject beforeEnfiladisses;
    public float beforeDuration = 2f;

    bool inClimbers = false;

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
        climbersCanvas.enabled = false;   
        beforeEnfiladisses.SetActive(false);
    }

    public void JocClimbers(Ingredient ingredient)
    {
        if (inClimbers) return;      // ja estem jugant, ignorem més peticions
        inClimbers = true;

        currentIngredient = ingredient;

        StartCoroutine(ShowBeforeAndStart());
    }
    private IEnumerator ShowBeforeAndStart()
    {
        beforeEnfiladisses.SetActive(true);
        // Esperem encara que timeScale = 0 després
        yield return new WaitForSecondsRealtime(beforeDuration);

        // Amaguem la intro
        beforeEnfiladisses.SetActive(false);
        // COMPROBACIONES  
        if (climbersCanvas == null)
        {
            Debug.LogError("[StartClimbers] climbersCanvas NO está asignado.");
            yield break;
        }
        if (climbersLogic == null)
        {
            Debug.LogError("[StartClimbers] climbersLogic NO está asignado.");
            yield break;
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


        //AFEGIT ARA
        // Si per alguna raó ja hi havia subscrit el nostre handler, el traiem
        climbersLogic.onWin -= HandleWin;
        climbersLogic.onQuit -= HandleQuit;
        //AFEGIT ARA

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
        inClimbers = false;
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
