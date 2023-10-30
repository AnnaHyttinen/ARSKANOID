using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector3 mousePosition;

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, -120, 0);

        if (rb != null)
        {
            rb.MovePosition(mousePosition);
        }
    }
}
