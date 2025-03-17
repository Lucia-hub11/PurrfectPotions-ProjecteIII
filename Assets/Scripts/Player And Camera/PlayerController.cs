using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float moveSpeed = 7.0f;
    private InputController _inputController;

    void Start()
    {
        _inputController = GetComponent<InputController>();
    }

    void Update()
    {
        Vector2 move = _inputController.Move;
        Vector3 moveDirection = new Vector3(move.x, 0, move.y);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        if (_inputController.Interact)
        {
        }

        if (_inputController.Click)
        {
        }
    }
}
