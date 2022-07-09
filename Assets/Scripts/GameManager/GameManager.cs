using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager GM;
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
}
