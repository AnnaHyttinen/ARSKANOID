using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Ball : MonoBehaviour
{
    //introducing variables: 
    public float speed = 120.0f;
    private int hitCount;
    private int tileCount;
    public GameObject powerUp;
    private Vector3 location;
    public AudioSource sound;
    public bool explosive;

    private void Start()
    {
        explosive = false;

        //giving a push for a ball to begin with:
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rules for colliding with a racket: 
        if(collision.gameObject.name == "Racket")
        {
            float x = hitFactor(transform.position, collision.transform.position, 
                collision.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        //rules for colliding with a tile:
        if(collision.gameObject.name == "Tile" && explosive)
        {
            //explosive events
            speed = 160f;
            hitCount = 0;
            Debug.Log("Explosive events!");

            //disabling explosive
            if(hitCount >= 5)
            {
                explosive = false;
            }
        }

        if(collision.gameObject.tag == "Tile")
        {
            sound = GetComponent<AudioSource>();
            sound.Play();

            //speeding up the ball:
            hitCount += 1;
            if(hitCount >= 10)
            {
                speed += 20.0f;
                hitCount = 0;
            }

            //instantiating the power ups:
            tileCount++;
            if (tileCount == 7)
            {
                location = transform.position;
                Instantiate(powerUp, location, Quaternion.identity);
                tileCount = 0;
            }
        }

        //rules for colliding with a floor:
        if(collision.gameObject.tag == "Floor")
        {
            //resetting the position of the ball: 
            transform.position = new Vector3(2, -85, 0);

            speed = 120.0f;

            //pushing the ball back to movement: 
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
    }

    //a hit factor calculator:
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
}
