using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    //setting a component from the object, introducing a variable for mouse position: 
    public Rigidbody2D rb;
    Vector3 mousePosition;

    private void Update()
    {
        //defining and adjusting the variable for mouse position: 
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, -120, 0);

        //moving the rigidbody based on this mouse position: 
        if (rb != null)
        {
            rb.MovePosition(mousePosition);
        }
    }
}
