using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursor : MonoBehaviour
{
    public RectTransform cursorRect;
    public Sprite cursorSprite;
    public Vector2 hotspot = Vector2.zero;
    private Image imageComp;

    void Awake()
    {
        imageComp = cursorRect.GetComponent<Image>();
    }

    public void Activate()
    {
        // Oculta el cursor del sistema
        Cursor.visible = false;
        // Asigna sprite
        imageComp.sprite = cursorSprite;
        // Muestra el cursor UI
        cursorRect.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        Cursor.visible = true;
        cursorRect.gameObject.SetActive(false);
    }

    void Update()
    {
        // Mueve el UI cursor a la posición del ratón
        cursorRect.position = Input.mousePosition;
    }
}
