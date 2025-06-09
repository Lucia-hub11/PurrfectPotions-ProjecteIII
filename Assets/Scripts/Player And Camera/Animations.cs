using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        
        if (anim == null)
            Debug.LogError("¡No hay Animator en este GameObject!");
    }

    void Update()
    {

        //if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        //{
        //    anim.SetBool("Move", true);
        //}
        //else
        //{
        //    anim.SetBool("Move", false);
        //}

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        bool isMoving = Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f;

        // Actualitzar Move a l'animator
        anim.SetBool("Move", isMoving);
    }
}