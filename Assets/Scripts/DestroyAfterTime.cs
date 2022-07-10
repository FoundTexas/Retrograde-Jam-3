using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float life = 1;
    void Start()
    {
        Destroy(this.gameObject, life);
    }
}
