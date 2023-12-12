using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    //eventually this got established just for the button
    public void Level1()
    {
        //new game button
        SceneManager.LoadScene("Level1");
    }
}
