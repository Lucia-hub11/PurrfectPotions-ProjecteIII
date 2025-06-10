using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursor : MonoBehaviour
{
    [SerializeField] private RectTransform cursorRect;
    [SerializeField] private Sprite cursorSprite;

    private Image imageComp;

    void Awake()
    {
        imageComp = cursorRect.GetComponent<Image>();
        Deactivate();
    }

    void Update()
    {
        // Mueve el UI cursor a la posición del ratón
        cursorRect.position = Input.mousePosition;
    }

    public void Activate()
    {
        Cursor.visible = false;
        imageComp.sprite = cursorSprite;
        cursorRect.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        Cursor.visible = true;
        cursorRect.gameObject.SetActive(false);
    }

    public void ResetPosition(Vector2 screenPos)
    {
        cursorRect.position = screenPos;
    }
}
