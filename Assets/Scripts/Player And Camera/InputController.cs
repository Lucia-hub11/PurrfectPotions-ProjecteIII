using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private Vector2 _move;
    public Vector2 Move => _move;

    private Vector2 _look;
    public Vector2 Look => _look;

    private bool _interact;
    public bool Interact => _interact;

    private bool _click;
    public bool Click => _click;

    private void OnMove(InputValue input)
    {
        _move = input.Get<Vector2>();
    }

    private void OnLook(InputValue input)
    {
        _look = input.Get<Vector2>();
    }

    private void OnInteract()
    {
        _interact = true;
    }

    private void OnClick()
    {
        _click = true;
    }

    private void LateUpdate()
    {
        _interact = false;
        _click = false;
    }
}
