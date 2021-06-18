using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDetection : MonoBehaviour
{
     public float Enemiesspeed;
    //private Animator anim;
    private Rigidbody2D rb;

    public float checkRadius = 1;

    private float waitTime;
    public float startwaitTime;


    public Transform moveSpot;

    private bool isGround;
    public Transform groundcheck;
    public LayerMask whatisground;

    public int Xdirection;

    private bool isWall;
    public Transform wallcheck;
    public LayerMask whatiswall;

    public Health player;
    private Transform target;

    bool facingright = true;

    void Start()
    {
        waitTime = startwaitTime;
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Xdirection, 0));
        isGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatisground);
        isWall = Physics2D.OverlapCircle(wallcheck.position, checkRadius, whatiswall);

        // moving
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Xdirection, 0) * Enemiesspeed;
        

        if (hit.distance < 0.4f)
        {
            
            flip();
        }

        if (hit.distance < 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2 (moveSpot.position.x, transform.position.y), Enemiesspeed * Time.deltaTime);

            if(Vector2.Distance(transform.position,moveSpot.position) < 0.2f)
            {
                if(waitTime <=0)
                {
                    waitTime = startwaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
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
