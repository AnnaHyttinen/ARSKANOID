using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroying a tile:
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
