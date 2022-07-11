using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject effect;
    GameObject target;
    public float speed, life;
    Rigidbody2D projectileRB;
    // Start is called before the first frame update
    void Start()
    {
        projectileRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = (target.transform.position - transform.position).normalized * speed;
        projectileRB.velocity = new Vector2(direction.x, direction.y);
        Destroy(this.gameObject, life);
    }

    private void OnDestroy()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

    }
}
