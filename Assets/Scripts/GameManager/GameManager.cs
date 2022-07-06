using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager GM;
    void Start()
    {
        if (GM == null)
        {
            GM = this;
        }
        else if ( GM != null)
        {
            if(GM != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
