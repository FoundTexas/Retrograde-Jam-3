using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour
{
    public int RenderDistance;
    List<GameObject> objs = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ob in objs)
        {
            gameObject.SetActive(Vector2.Distance(transform.position, ob.transform.position) < RenderDistance);
        }
    }

    public void Add(GameObject other)
    {
        objs.Add(other);
    }
    public void Remove(GameObject other)
    {
        objs.Remove(other);
    }
}
