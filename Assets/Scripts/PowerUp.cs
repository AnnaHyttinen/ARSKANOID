using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using Random = UnityEngine.Random;

public class PowerUp : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color color;
    private int state;
    private float targetTime = 1f;
    private Vector3 location;
    public GameObject rain; //attached to rain
    public GameObject floor; //attached to background
    public GameObject ball; //attached to a ball

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

    void TimerEnded()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        state = Random.Range(0, 5);

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

    void Actions()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();

        if (sprite.color == Color.green)
        {
            Debug.Log("life");
            //floor.life += 1;
        }
        if (sprite.color == Color.blue)
        {
            Debug.Log("slow");
            //ball.speed = 80.0f;
        }
        if (sprite.color == Color.red)
        {
            Debug.Log("fast");
            //ball.speed = 180.0f;
        }
        if (sprite.color == Color.cyan)
        {
            Debug.Log("explosive");
            //ball.explosive = true;
        }
        if (sprite.color == Color.white)
        {
            Debug.Log("rain");

            Rain();
            Rain();
            Rain();
            Rain();
            Rain();
        }
    }

    void Rain()
    {
        location = new Vector3(Random.Range(-133, 133), Random.Range(110, 120), -3);
        Instantiate(rain, location, Quaternion.identity);
    }
}
