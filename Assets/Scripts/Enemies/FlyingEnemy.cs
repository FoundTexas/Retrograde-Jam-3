using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float visionRange;

    [SerializeField]
    private float range;

    [SerializeField]
    private float fireRate;

    private float nextShotTime;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private GameObject projectilePartent;


    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < visionRange && distanceFromPlayer > range)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed*Time.deltaTime);
        }
        else if(distanceFromPlayer <= range && nextShotTime < Time.time)
        {
            Instantiate(projectile, projectilePartent.transform.position, Quaternion.identity);
            nextShotTime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, visionRange);
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
