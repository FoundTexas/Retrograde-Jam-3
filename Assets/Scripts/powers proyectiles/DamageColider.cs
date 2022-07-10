using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColider : MonoBehaviour
{
    [SerializeField] int dmg = 1;
    [SerializeField] bool destroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != this.tag && collision.gameObject != this.gameObject)
        {
            IDamaged col = collision.GetComponent<IDamaged>();
            if (col != null)
            {
                col.TakeDamage(dmg);

                if (destroy)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
