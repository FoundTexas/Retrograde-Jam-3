using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D projectileRB;
    // Start is called before the first frame update
    void Start()
    {
        projectileRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = (target.transform.position - transform.position).normalized * speed;
        projectileRB.velocity = new Vector2(direction.x, direction.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
