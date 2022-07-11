using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatProjectile : MonoBehaviour
{
    [SerializeField] GameObject effect;
    public float speed, life;
    Rigidbody2D projectileRB;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        projectileRB = GetComponent<Rigidbody2D>();
        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            direction = (-transform.right * Time.deltaTime).normalized * speed;
        }
        else
        {
            direction = (transform.right * Time.deltaTime).normalized * speed;
        }
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
