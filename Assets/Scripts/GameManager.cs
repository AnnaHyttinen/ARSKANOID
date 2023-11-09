using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public int life;
    public float speed;
    public bool explosive;

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
