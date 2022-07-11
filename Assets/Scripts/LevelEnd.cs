using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(collision.name == "cat")
            {
                FindObjectOfType<SceneLoader>().ReandomScene();
            }
        }
    }
}
