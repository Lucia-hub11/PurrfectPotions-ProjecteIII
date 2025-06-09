using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropObjects : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Ingredient ploma;
    public Ingredient aigua;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;   
    private CanvasGroup canvasGroup;  
    private Vector3 originalPosition;
    public ObjectSlot objectSlot;
    public InventoryManager inventoryManager;
    public BottomInventoryManager bottomInventoryManager;

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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            string objecte = objectSlot.objectName;
            string target = hit.collider.gameObject.name;

            //Unes cuantes combinacions d'exemple, per l'hito cal posar les correctes
            if ((objecte == "Diamond" && target == "IngredientCorb"))
            {
                inventoryManager.ClearObject(objecte);
                bottomInventoryManager.ClearObject(objecte);
                //objectSlot.ClearObject();
                rectTransform.position = originalPosition;
                Debug.Log("Objeto correcto!"  + hit.collider.gameObject.name);

                ploma.CollectIngredient();
                ploma.crowTalk.HideCrowTalk();
                //AQUÍ la acción que toque; por ejemplo hacer la poción o obtener la pluma o así.
                //Debería tanto funcionar para objetos como ingredientes (todos los items del inventario y objetos 3d del juego).
            }
            else if ((objecte == "Galleda" && target =="Pou"))
            {
                inventoryManager.ClearObject(objecte);
                bottomInventoryManager.ClearObject(objecte);
                rectTransform.position = originalPosition;
                Debug.Log("Objeto correcto!"  + hit.collider.gameObject.name);
                aigua.CollectIngredient();
                //si es el primer ingrediente que encuentra activar tutorial
            }
            else{
                rectTransform.position = originalPosition;
                Debug.Log("Objeto incorrecto :(" + hit.collider.gameObject.name);
                Debug.Log("Item: " + objectSlot.objectName);
            }
        }
        else
        {
            rectTransform.position = originalPosition;
        }
    }
}
