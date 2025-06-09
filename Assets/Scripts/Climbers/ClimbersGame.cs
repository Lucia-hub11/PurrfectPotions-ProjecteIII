using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ClimbersGame : MonoBehaviour
{
    public UICursor uiCursor;
    public RectTransform startPoint;
   
    public string wallTag = "Wall";
    public string finishTag = "Finish";

    //events per StartClimbers
    public event Action onWin;
    public event Action onQuit;

    // Interno
    private Canvas canvas;
    private GraphicRaycaster raycaster;
    private PointerEventData pointerData;
    private List<RaycastResult> results = new List<RaycastResult>();
    private bool isPlaying = false;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        raycaster = GetComponent<GraphicRaycaster>();
        pointerData = new PointerEventData(EventSystem.current);
        canvas.enabled = false;
    }

    public void StartMinigame()
    {
        isPlaying = true;
        canvas.enabled = true;
        uiCursor.Activate();

        //posar el cursor virtual a l'inici
        uiCursor.cursorRect.position = startPoint.position;
    }

    public void ResetMinigame()
    {
        isPlaying = false;
        canvas.enabled = false;
        uiCursor.Deactivate();
    }

    //public void EndMinigame(bool won)
    //{
    //    uiCursor.Deactivate();
    //    canvas.enabled = false;

    //    //Afegir la recompensa de la flor transl·lúcida
    //}
    
    
    void Update()
    {
        if (!isPlaying) return;

        //preparar el PointerEventData amb la posició actual del ratolí
        pointerData.position = Input.mousePosition;
        results.Clear();
        raycaster.Raycast(pointerData, results);

        foreach (var r in results)
        {
            if (r.gameObject.CompareTag(wallTag))
            {
                // Toca pared -> reset al inicio
                uiCursor.cursorRect.position = startPoint.position;
                break;
            }
            else if (r.gameObject.CompareTag(finishTag))
            {
                // Ha llegado a meta -> disparar win
                isPlaying = false;
                onWin?.Invoke();
                break;
            }
        }
    }
}
