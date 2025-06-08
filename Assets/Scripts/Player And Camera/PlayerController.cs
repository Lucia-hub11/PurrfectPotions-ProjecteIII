using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7.0f;
    private InputController _inputController;
    public float rotationSpeed;
    

    void Start()
    {
        _inputController = GetComponent<InputController>();
    }

    void Update()
    {
        Vector2 move = _inputController.Move;
        Vector3 moveDirection = new Vector3(move.x, 0, move.y);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        if(moveDirection!= Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation= Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed*Time.deltaTime);
        }
        
    }
}
