using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] Transform checkTransform;

    public LayerMask whatCanColide;

    bool colided;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colided = Physics2D.OverlapCircle(feetpos.position, 0.2f, whatIsGround);
    }
}
