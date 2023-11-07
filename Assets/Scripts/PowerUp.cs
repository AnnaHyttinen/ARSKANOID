using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUp : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color color;
    private int state;
    private float targetTime = 1f;

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            TimerEnded();
            targetTime = 1.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //actions when hitting a tile or a ball: ... wait a minute!
        if (collision.gameObject.name == "Racket")
        {
            Actions();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }

    void Actions()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        
        if (sprite.color == Color.green)
        {
            //extra life
        }
        if (sprite.color == Color.blue)
        {
            //slow ball
        }
        if (sprite.color == Color.red)
        {
            //fast ball
        }
        if (sprite.color == Color.cyan)
        {
            //explosive ball
        }
        if (sprite.color == Color.white)
        {
            //rain to melt tiles
        }
    }

    void TimerEnded()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        state = Random.Range(0, 4);

        switch (state)
        {
            case 0:
                sprite.color = Color.green;
                break;
            case 1:
                sprite.color = Color.blue;
                break;
            case 2:
                sprite.color = Color.red;
                break;
            case 3:
                sprite.color = Color.cyan;
                break;
            case 4:
                sprite.color = Color.white;
                break;
        }
    }
}
