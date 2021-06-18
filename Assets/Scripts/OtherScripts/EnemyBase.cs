using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float Enemiesspeed;
    //private Animator anim;
    private Rigidbody2D rb;

    public float checkRadius = 1;

    private bool isGround;
    public Transform groundcheck;
    public LayerMask whatisground;

    public int Xdirection;

    private bool isWall;
    public Transform wallcheck;
    public LayerMask whatiswall;

    public Health player;

    bool facingright = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Xdirection, 0));
        isGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatisground);
        isWall = Physics2D.OverlapCircle(wallcheck.position, checkRadius, whatiswall);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Xdirection, 0) * Enemiesspeed;

        if (hit.distance < 0.4f)
        {
            
            flip();
        }

    }


    void flip()
    {

        if (Xdirection > 0)
        {
            facingright = !facingright;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
            Xdirection = -1;
        }
        else
        {
            facingright = !facingright;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
            Xdirection = 1;
        }
    }
}