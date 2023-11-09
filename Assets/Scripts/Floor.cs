using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    //introducing variables for the UI
    private GameManager gameManager;
    public GameObject text;

    //introducing the ball
    public GameObject ball;

    private void Start()
    {
        text = GetComponentInChildren<Floor>().text;
        //establishing the text element:
        text.GetComponent<Text>().text = "Life " + gameManager.life;

        gameManager = GameManager.manager;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //the floor detector of death:
            gameManager.life -= 1;

            if (gameManager.life <= 0)
            {
                text.GetComponent<Text>().text = "Game Over";
                Destroy(ball);
            }
            else
            {
                text.GetComponent<Text>().text = "Life " + gameManager.life;
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
