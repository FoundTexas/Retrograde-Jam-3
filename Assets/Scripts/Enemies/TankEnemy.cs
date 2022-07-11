using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [SerializeField] Transform checkTransform;

    [SerializeField]
    private float visionRange;

    [SerializeField]
    private float fireRate;

    private float nextShotTime;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private GameObject projectilePartent;

    Vector2 dir = Vector2.left;

    public LayerMask whatCanColide;

    public bool colided, turn, OnGround, CheckGround;

    Rigidbody2D rb;
    private Transform player;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (turn)
        {
            dir = Vector2.right;
            transform.eulerAngles = Vector3.up * 180;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if(distanceFromPlayer <= visionRange)
        {
            if (nextShotTime < Time.deltaTime)
            {
                Instantiate(projectile, projectilePartent.transform.position, Quaternion.identity);
                nextShotTime = Time.deltaTime + fireRate;
            }
        }
        else if(distanceFromPlayer > visionRange)
        {
          colided = Physics2D.OverlapCircle(checkTransform.position, 0.2f, whatCanColide);

          RaycastHit2D hit = Physics2D.Raycast(checkTransform.position, Vector2.down, 1, whatCanColide);

          OnGround = hit.transform != null;

          if(CheckGround)
          {
              if (!OnGround)
              {
                  colided = true;
              }
          }

          if (colided)
          {
              transform.eulerAngles = turn ? Vector3.zero : Vector3.up * 180;
              turn = !turn;
              dir *= -1;
          }

          if (OnGround)
          {
              rb.velocity = Vector2.zero;
              rb.velocity = new Vector2(dir.x * 3, rb.velocity.y);
          }
        }




    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
