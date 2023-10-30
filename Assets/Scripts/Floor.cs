using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    //introducing variables for the use of UI:
    public int life;
    public GameObject text;

    //getting the ball object in case of game over:
    public GameObject ball;

    private void Start()
    {
        //establishing the text element:
        this.text.GetComponent<Text>().text = "Life " + life;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //the floor detector of death:
            life -= 1;

            if (life <= 0)
            {
                this.text.GetComponent<Text>().text = "Game Over";
                Destroy(ball);
            }
            else
            {
                this.text.GetComponent<Text>().text = "Life " + life;
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
