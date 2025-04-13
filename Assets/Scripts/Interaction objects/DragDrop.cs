using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;   
    private CanvasGroup canvasGroup;  
    private Vector3 originalPosition;
    public ObjectSlot objectSlot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.position;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //seguimiento item del cursor
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, eventData.position, canvas.worldCamera, out position);
        rectTransform.localPosition = position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Leer tag de ingrediente y objeto, hay que hacer arrays para recorrer o compararlos uno a uno.
        //Si es el correcto: imagen se elimina pero prefab vuelve vacío a la posición original. Ocurre la acción.
        //Si es el incorrecto: imagen vuelve a la posición original y no ocurre la acción.
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            objectSlot.ClearObject();
            rectTransform.position = originalPosition;
            Debug.Log("Objeto 3D tocado: " + hit.collider.gameObject.name);
        }
        else
        {
            rectTransform.position = originalPosition;
        }
    }
}
