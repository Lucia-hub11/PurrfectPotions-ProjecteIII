using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;  // El canvas que contiene el objeto UI
    private RectTransform rectTransform;     // RectTransform del objeto UI
    private CanvasGroup canvasGroup;         // Para cambiar la opacidad y bloquear raycasts
    private Vector3 originalPosition;        // Posición original para revertir si no se hace el drop

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Guardamos la posición original del objeto para regresarlo si no se hace el drop en un objeto 3D
        originalPosition = rectTransform.position;
        canvasGroup.alpha = 0.6f;  // Reducimos la opacidad al arrastrar
        canvasGroup.blocksRaycasts = false;  // Desactivamos raycasts mientras se está arrastrando
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convertimos la posición del ratón en coordenadas locales dentro del Canvas
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, canvas.worldCamera, out position);
        rectTransform.localPosition = position;  // Actualizamos la posición del objeto en el Canvas
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;  // Restauramos la opacidad
        canvasGroup.blocksRaycasts = true;  // Volvemos a activar los raycasts

        // Ahora calculamos el raycast en el mundo 3D al soltar el objeto
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // Creamos un ray desde la cámara hacia el ratón
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))  // Si el raycast toca un objeto 3D
        {
            // Aquí convertimos la posición del mouse (pantalla) en un punto en el mundo 3D
            rectTransform.position = hit.point;  // Colocamos el objeto UI en la posición del impacto
            Debug.Log("Objeto 3D tocado: " + hit.collider.gameObject.name);  // Opcional: para verificar qué objeto fue tocado
        }
        else
        {
            // Si no tocó ningún objeto 3D, regresamos el objeto UI a su posición original
            rectTransform.position = originalPosition;
        }
    }
}
