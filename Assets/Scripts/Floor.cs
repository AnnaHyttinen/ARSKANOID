using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour
{
    //introducing variables for the UI
    private GameManager gameManager;
    public GameObject text;

    //introducing the ball, scene
    public GameObject ball;
    private string scene;

    private float time = 2f;
    public string levelToLoad;
    public static bool pause;

    private void Start()
    {
        gameManager = GameManager.manager;
        //establishing the text element:
        text = GetComponentInChildren<Floor>().text;

        scene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        //setting up a timer for a power up color change, refreshing UI etc
        time -= Time.deltaTime;

        if (time <= 0.0f && scene != "Menu" && scene != "Ending")
        {   
            //updating the UI
            text.GetComponent<Text>().text = "Life " + gameManager.life;
            time = 2.0f;

            //loading a new scene
            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
            if (tiles.Length <= 0)
            {
                gameManager.Level(levelToLoad);
            }
        }

        //checking for pause
        if(Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
            Pause();
            Debug.Log(pause);
        }

        //checking for menu
        if(Input.GetKeyDown(KeyCode.M)) 
        {
            gameManager.Level("Menu");
        }

        //checking for quit by esc
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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

    void Pause()
    {
        if(pause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
