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

    private float time = 2f;

    private void Start()
    {
        gameManager = GameManager.manager;
        //establishing the text element:
        text = GetComponentInChildren<Floor>().text;
        text.GetComponent<Text>().text = "Life " + gameManager.life;
    }

    void Update()
    {
        //setting up a timer for a power up color change
        time -= Time.deltaTime;

        if (time <= 0.0f)
        {
            text.GetComponent<Text>().text = "Life " + gameManager.life;
            time = 2.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //the floor detector of death:
            gameManager.life -= 1;

            if (gameManager.life <= 0)
            {
                //text = GetComponentInChildren<Floor>().text;
                text.GetComponent<Text>().text = "Game Over";
                Destroy(ball);
            }
            else
            {
                //text = GetComponentInChildren<Floor>().text;
                text.GetComponent<Text>().text = "Life " + gameManager.life;
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
