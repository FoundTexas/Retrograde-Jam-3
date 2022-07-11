using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] float speed, jump, jumpTime;
    [SerializeField] Transform feetpos;
    [SerializeField] Animator anim;
    Rigidbody2D rb;
    float moveInput, jumpTimer;
    bool isGrounded, isjumping;
    public LayerMask whatIsGround;

    [SerializeField] Vector2 minXmaxX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    private void Update()
    {
        transform.eulerAngles = moveInput >= 0 ? Vector3.zero : Vector3.up*180;

        isGrounded = Physics2D.OverlapCircle(feetpos.position, 0.2f, whatIsGround);
        if (isGrounded)
        {
            rb.gravityScale = 3;
        }
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.gravityScale = 3;
            isjumping = true;
            jumpTimer = 0;
            rb.velocity = Vector2.up * jump;
        }
        if (Input.GetKey("space")&& isjumping)
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jump;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isjumping = false;
                rb.gravityScale = 5;
            }
        }
        if (Input.GetKeyUp("space"))
        {
            isjumping = false;
            rb.gravityScale = 5;
        }

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minXmaxX.x, minXmaxX.y),
            transform.position.y);

        anim.SetBool("OnGround", isGrounded);
        anim.SetFloat("mov", rb.velocity.magnitude);
    }
}
