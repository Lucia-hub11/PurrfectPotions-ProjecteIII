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
    [SerializeField] private string wallTag = "Wall";
    [SerializeField] private string finishTag = "Finish";

    public event Action onWin;
    public event Action onQuit;

    private GraphicRaycaster raycaster;
    private PointerEventData pointerData;
    private List<RaycastResult> results = new List<RaycastResult>();
    private bool isPlaying = false;

    private void Awake()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        pointerData = new PointerEventData(EventSystem.current);
    }

    /// <summary>Arranca el minijuego</summary>
    public void StartMinigame()
    {
        if (uiCursor == null || startPoint == null)
        {
            Debug.LogError("ClimbersGame: uiCursor o startPoint no asignados");
            return;
        }

        isPlaying = true;
        uiCursor.Activate();
        uiCursor.SetPosition(startPoint.position);
    }

    /// <summary>Para el minijuego</summary>
    public void ResetMinigame()
    {
        isPlaying = false;
        uiCursor.Deactivate();
    }

    private void Update()
    {
        if (!isPlaying) return;

        // Raycast desde la posición del cursor
        pointerData.position = Input.mousePosition;
        results.Clear();
        raycaster.Raycast(pointerData, results);

        foreach (var hit in results)
        {
            if (hit.gameObject.CompareTag(wallTag))
            {
                Debug.Log("¡Pared tocada! Cerrando minijuego...");
                isPlaying = false;
                onQuit?.Invoke();
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
}