using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    public int life = 3;
    public GameObject text;
    private void Start()
    {
        this.text.GetComponent<Text>().text = "Life " + life;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        life -= 1;
        if (life <= 0)
        {
            this.text.GetComponent<Text>().text = "Game Over";
        }
        else
        {
            this.text.GetComponent<Text>().text = "Life " + life;
        }
    }
}
