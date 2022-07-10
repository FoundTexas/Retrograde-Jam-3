using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager GM;
    static int lives = 7;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (GM == null)
        {
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(this.gameObject);

        }
    }

    public static void RestLives()
    {
        lives = 7;
    }
    public static void UpdateLives(int i)
    {
        lives += i;
    }
    public static int Getlives()
    {
        return lives;
    }
}
