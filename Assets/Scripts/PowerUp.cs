using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color color;
    private int state;
    public float targetTime = 10f;

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            TimerEnded();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //actions when hitting a tile or a ball: ... wait a minute!
        if (collision.gameObject.name == "Racket")
        {
            Debug.Log("Gotcha!");
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
        color = sprite.color;
        state = Random.Range(0, 4);
        Debug.Log(state);

        switch (state)
        {
            case 0:
                color = Color.green;
                break;
            case 1:
                color = Color.blue;
                break;
            case 2:
                color = Color.red;
                break;
            case 3:
                color = Color.cyan;
                break;
            case 4:
                color = Color.white;
                break;
        }
    }
}
