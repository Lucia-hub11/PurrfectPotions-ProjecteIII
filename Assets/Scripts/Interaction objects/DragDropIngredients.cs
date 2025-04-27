using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropIngredients : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 originalPosition;
    public IngredientSlot ingredientSlot;
    public InventoryManager inventoryManager;
    public BottomInventoryManager bottomInventoryManager;

    public Camera StaticCamera;

    public Canvas potion;
    int contadorIngredients = 0 ;

    private void Start()
    {
        potion.enabled = false;
    }

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
        //Cosas que tengo que hacer aquí
        //Leer tag de ingrediente y objeto, hay que hacer arrays para recorrer o compararlos uno a uno.
        //Si es el correcto: imagen se elimina pero prefab vuelve vacío a la posición original. Ocurre la acción.
        //Si es el incorrecto: imagen vuelve a la posición original y no ocurre la acción.
        //Hacer diferenciación entre ingrediente y objeto porque van a scripts diferentes.
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        Ray ray = StaticCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            string ingredient = ingredientSlot.ingredientName;
            string target = hit.collider.gameObject.name;

            //Unes cuantes combinacions d'exemple, per l'hito cal posar les correctes
            if ((ingredient == "Tear" && target == "Calder") ||
                (ingredient == "Crow Feather" && target == "Calder") ||
                (ingredient == "Invisible Mushroom" && target == "Calder"))
            {
                inventoryManager.ClearIngredient(ingredient);
                bottomInventoryManager.ClearIngredient(ingredient);
                //ingredientSlot.ClearIngredient();
                rectTransform.position = originalPosition;
                Debug.Log("Objeto correcto!" + hit.collider.gameObject.name);
                //AQUÍ la acción que toque; por ejemplo hacer la poción o obtener la pluma o así.
                //Debería tanto funcionar para objetos como ingredientes (todos los items del inventario y objetos 3d del juego).

                contadorIngredients++;
            }
            else
            {
                rectTransform.position = originalPosition;
                Debug.Log("Objeto incorrecto :(" + hit.collider.gameObject.name);
                Debug.Log("Item: " + ingredientSlot.ingredientName);
            }
        }
        else
        {
            rectTransform.position = originalPosition;
        }

        if (contadorIngredients == 3)
        {
            potion.enabled = true;
        }
    }
}
