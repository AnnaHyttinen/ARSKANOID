using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer spr;
    private double sprA;
    private int health;

    private void Start()
    {
        //getting access to opacity and setting up health:
        spr = GetComponent<SpriteRenderer>();
        sprA = spr.color.a;
        health = (int)(sprA / 0.2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //actions when hitting a tile:
        if (collision.gameObject.tag == "Player")
        {
            health -= 1;
            Color oldColor = spr.color;
            Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a - 0.2f);
            spr.color = newColor;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Rain")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
