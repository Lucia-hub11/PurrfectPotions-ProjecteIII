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
    public IngredientSlot ingredientSlot;

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
        //Cosas que tengo que hacer aqu�
        //Leer tag de ingrediente y objeto, hay que hacer arrays para recorrer o compararlos uno a uno.
        //Si es el correcto: imagen se elimina pero prefab vuelve vac�o a la posici�n original. Ocurre la acci�n.
        //Si es el incorrecto: imagen vuelve a la posici�n original y no ocurre la acci�n.
        //Hacer diferenciaci�n entre ingrediente y objeto porque van a scripts diferentes.
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            string ingredient = IngredientSlot.ingredientName;
            string objecte = ObjectSlot.ingredientName;
            string target = hit.collider.gameObject.name;

            //Unes cuantes combinacions d'exemple, per l'hito cal posar les correctes
            if ((ingredient == "llagrima" && target == "calder") ||
                (ingredient == "poma" && target == "calder") ||
                (ingredient == "sucre" && target == "calder") ||
                (objecte == "diamant" && target == "corb"))
            {
                objectSlot.ClearObject();
                ingredientSlot.ClearIngredient();
                rectTransform.position = originalPosition;
                Debug.Log("Objeto correcto!"  + hit.collider.gameObject.name);
            }
            else{
                rectTransform.position = originalPosition;
                Debug.Log("Objeto incorrecto :(" + hit.collider.gameObject.name);
            }
        }
        else
        {
            rectTransform.position = originalPosition;
        }
    }
}
