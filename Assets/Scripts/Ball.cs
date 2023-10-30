using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 120.0f;
    private int hitCount;
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Racket")
        {
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if(collision.gameObject.tag == "Tile")
        {
            hitCount += 1;
            if(hitCount >= 10)
            {
                speed += 20.0f;
                hitCount = 0;
            }
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
}
