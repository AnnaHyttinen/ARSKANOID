using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject text;
    public GameObject ball;

    private string scene;
    private float time = 0.5f;
    public string levelToLoad;
    public static bool pause;

    private void Start()
    {
        gameManager = GameManager.manager;

        //establishing the UI text element:
        text = GetComponentInChildren<Floor>().text;
        
        scene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        //setting up a timer for checking certain changes once in a while
        time -= Time.deltaTime;

        if (time <= 0.0f && scene != "Menu" && scene != "Ending" && gameManager.life > 0)
        {   
            //updating the UI
            text.GetComponent<Text>().text = scene + "\nLife " + gameManager.life + 
                "\n" + gameManager.powerText;
            time = 0.5f;

            //loading a new scene whenever running out of tiles
            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
            if (tiles.Length <= 0)
            {
                gameManager.Level(levelToLoad);
            }
        }

        //checking for pause button
        if(Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
            Pause();
            Debug.Log(pause);
        }

        //checking for menu button
        if(Input.GetKeyDown(KeyCode.M)) 
        {
            gameManager.Level("Menu");
            gameManager.life = 5;
            gameManager.explosive = false;
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
                text.GetComponent<Text>().text = scene + "\nLife " + gameManager.life +
                    "\n" + gameManager.powerText;
            }
        }
        else //anything else that could collide gets destroyed
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
