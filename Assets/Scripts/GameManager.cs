using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public int life;

    private void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if(manager != this)
        {
            Destroy(gameObject);
        }
    }
}
