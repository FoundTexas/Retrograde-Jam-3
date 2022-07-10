using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] Transform checkTransform;

    Vector2 dir = Vector2.left;

    public LayerMask whatCanColide;

    public bool colided, turn, OnGround, CheckGround;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (turn)
        {
            dir = Vector2.right;
            transform.eulerAngles = Vector3.up * 180;
        }
    }

    void Update()
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
