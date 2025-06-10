using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ClimbersGame : MonoBehaviour
{
    [SerializeField] private UICursor uiCursor;
    [SerializeField] private RectTransform startPoint;
    private string wallTag = "Wall";
    private string finishTag = "Finish";

    public event Action onWin;
    public event Action onQuit;

    private GraphicRaycaster raycaster;
    private PointerEventData pointerData;
    private List<RaycastResult> results = new List<RaycastResult>();
    private bool isPlaying = false;

    void Awake()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        pointerData = new PointerEventData(EventSystem.current);
    }
    public void StartMinigame()
    {
        if (uiCursor == null || startPoint == null)
        {
            Debug.LogError("ClimbersGame: uiCursor o startPoint no asignados");
            return;
        }

        isPlaying = true;
        uiCursor.Activate();
        uiCursor.ResetPosition(startPoint.position);
        //isPlaying = true;
    }

    public void ResetMinigame()
    {
        isPlaying = false;
        uiCursor.Deactivate();
    }

    void Update()
    {
        if (!isPlaying) return;

        pointerData.position = Input.mousePosition;
        results.Clear();
        raycaster.Raycast(pointerData, results);

        foreach (var hit in results)
        {
            if (hit.gameObject.CompareTag(wallTag))
            {
                Debug.Log("¡Pared tocada! Reiniciando al inicio...");
                // Sólo reposicionar el cursor UI
                uiCursor.ResetPosition(startPoint.position);
                return;
            }

            if (hit.gameObject.CompareTag(finishTag))
            {
                Debug.Log("Meta alcanzada!");
                isPlaying = false;
                onWin?.Invoke();
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPlaying = false;
            onQuit?.Invoke();
        }
    }
    //public UICursor uiCursor;
    //public RectTransform startPoint;

    //public string wallTag = "Wall";
    //public string finishTag = "Finish";

    ////events per StartClimbers
    //public event Action onWin;
    //public event Action onQuit;

    //// Interno
    //private Canvas canvas;
    //private GraphicRaycaster raycaster;
    //private PointerEventData pointerData;
    //private List<RaycastResult> results = new List<RaycastResult>();
    //private bool isPlaying = false;

    //private void Awake()
    //{
    //    canvas = GetComponent<Canvas>();
    //    raycaster = GetComponent<GraphicRaycaster>();
    //    pointerData = new PointerEventData(EventSystem.current);
    //    canvas.enabled = false;

    //    // Auto-asignar si faltan
    //    if (uiCursor == null)
    //        uiCursor = GetComponentInChildren<UICursor>();
    //    if (startPoint == null)
    //    {
    //        var t = transform.Find("StartPoint");
    //        if (t != null)
    //            startPoint = t as RectTransform;
    //    }
    //}

    //public void StartMinigame()
    //{
    //    // Comprueba cada referencia
    //    if (uiCursor == null)
    //        Debug.LogError("[ClimbersGame] uiCursor es null. ¿Lo arrastraste en el Inspector?");
    //    else if (uiCursor.cursorRect == null)
    //        Debug.LogError("[ClimbersGame] uiCursor.cursorRect es null. ¿Asignaste el Image en UICursor?");
    //    if (startPoint == null)
    //        Debug.LogError("[ClimbersGame] startPoint es null. ¿Lo arrastraste en el Inspector?");

    //    // Si alguna falta, salimos para evitar más errores
    //    if (uiCursor == null || uiCursor.cursorRect == null || startPoint == null)
    //        return;

    //    isPlaying = true;
    //    canvas.enabled = true;
    //    uiCursor.Activate();

    //    //posar el cursor virtual a l'inici
    //    uiCursor.cursorRect.position = startPoint.position;
    //}

    //public void ResetMinigame()
    //{
    //    isPlaying = false;
    //    canvas.enabled = false;
    //    uiCursor.Deactivate();
    //}

    ////public void EndMinigame(bool won)
    ////{
    ////    uiCursor.Deactivate();
    ////    canvas.enabled = false;

    ////    //Afegir la recompensa de la flor transl·lúcida
    ////}


    //void Update()
    //{
    //    if (!isPlaying) return;

    //    //preparar el PointerEventData amb la posició actual del ratolí
    //    pointerData.position = Input.mousePosition;
    //    results.Clear();
    //    raycaster.Raycast(pointerData, results);

    //    foreach (var r in results)
    //    {
    //        if (r.gameObject.CompareTag(wallTag))
    //        {
    //            // Toca pared = reset al inicio
    //            uiCursor.cursorRect.position = startPoint.position;
    //            break;
    //        }
    //        else if (r.gameObject.CompareTag(finishTag))
    //        {
    //            Debug.Log("He tocado FINISH");

    //            isPlaying = false;
    //            onWin?.Invoke();
    //            break;
    //        }
    //    }
    //}
}
