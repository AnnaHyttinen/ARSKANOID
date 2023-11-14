using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.FilePathAttribute;
using Random = UnityEngine.Random;

public class PowerUp : MonoBehaviour
{
    //variables for changing color, randomizing state and setting a timer
    private SpriteRenderer sprite;
    private int state;
    private float targetTime = 2f;

    //variables for spawning of the rain
    private Vector3 location;
    public GameObject rain;

    //variables to access other scripts
    public Floor floor;
    public Ball ball;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.manager;
    }

    void Update()
    {
        //setting up a timer for a power up color change
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            TimerEnded();
            targetTime += 2f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroying the power up -object and taking actions needed
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
        //determining the color for a power up
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
                sprite.color = Color.yellow;
                break;
            case 3:
                sprite.color = Color.red;
                break;
            case 4:
                sprite.color = Color.white;
                break;
        }
    }

    void Actions()
    {
        //to get a color of power up
        sprite = GetComponentInChildren<SpriteRenderer>();

        //power up actions
        if (sprite.color == Color.green)
        {
            gameManager.powerText = ("Life");
            gameManager.life += 1;
        }
        if (sprite.color == Color.blue)
        {
            gameManager.powerText = ("Slow");
            gameManager.speed = 100.0f;
        }
        if (sprite.color == Color.yellow)
        {
            gameManager.powerText = ("Fast");
            gameManager.speed = 180.0f;
        }
        if (sprite.color == Color.red)
        {
            gameManager.powerText = ("Hinode");
            gameManager.explosive = true;
            gameManager.speed = 160f;
        }
        if (sprite.color == Color.white)
        {
            gameManager.powerText = ("Rain");
            Rain(); Rain(); Rain(); Rain(); Rain();
        }
    }

    void Rain()
    {
        location = new Vector3(Random.Range(-133, 133), Random.Range(110, 120), -3);
        Instantiate(rain, location, Quaternion.identity);
    }
}
