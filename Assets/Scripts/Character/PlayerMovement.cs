using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float jumpforce = 5;
    private float moveinput;
    private Animator myanimation;

    private Rigidbody2D mycharacter;

    private bool facingright = true;

    private bool isGround;
    public Transform groundcheck;
    public float checkRadius = 1;
    public LayerMask whatisground;

    private int extraJump = 0;
    public int extrajumpvalue = 0;

    private bool isWall;
    public Transform wallcheck;
    public LayerMask whatiswall;

    public bool wallClimb;

    bool isDashing = false;


    // Start is called before the first frame update
    void Start()
    {
        extraJump = extrajumpvalue;
        mycharacter = GetComponent<Rigidbody2D>();
        myanimation = GetComponent<Animator>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatisground);
        isWall = Physics2D.OverlapCircle(wallcheck.position, checkRadius, whatiswall);
    }

    void Update()
    {
        if(isWall){

            wallClimb = true;
        } else {

            wallClimb = false;
        }

        if (isGround){

            extraJump = extrajumpvalue;
        }


        //if (isWall) {

        //    Debug.Log("Attach Wall");
        //}

        JumpCheck();
        HandleMovement();
        WallClimb();
        Onlanding();
    }

    void HandleMovement()
    {
        moveinput = Input.GetAxis("Horizontal");

        if (isGround)
        {
            mycharacter.velocity = new Vector2(moveinput * speed, mycharacter.velocity.y);
        }
        
        
         myanimation.SetFloat("Speed", Mathf.Abs(moveinput));

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            FindObjectOfType<AudioManager>().Play("dash");
            StartCoroutine("Dash");
        }

        if (facingright == false && moveinput > 0)
        {
            flip();
        }
        else if (facingright == true && moveinput < 0)
        {
            flip();
        }
    }

    void JumpCheck()
    {
        myanimation.SetBool("Jump", true);
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            FindObjectOfType<AudioManager>().Play("jump");
            myanimation.SetBool("Jump", true);
            mycharacter.velocity = Vector2.up * jumpforce;
            extraJump--;
       
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGround == true)
        {
            FindObjectOfType<AudioManager>().Play("jump");
            mycharacter.velocity = Vector2.up * jumpforce;
            
        }
    }

    public void Onlanding()
    {
        if (isGround)
        {
            myanimation.SetBool("Jump", false);
        }
    }

    void flip()
    {
        facingright = !facingright;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    public void WallClimb()
    {
        if(wallClimb && !isGround)
        {
            mycharacter.gravityScale = 0;
            FindObjectOfType<AudioManager>().Play("climb");
            mycharacter.velocity = new Vector2(mycharacter.velocity.x, 0);
            float climbMovement = Input.GetAxis("Vertical") * speed;
            mycharacter.velocity = new Vector2(0, climbMovement);
        }
        else
        {
            mycharacter.gravityScale = 1;
            mycharacter.velocity = new Vector2(moveinput * speed, mycharacter.velocity.y);
        }
    }

    IEnumerator Dash()
    {
    	isDashing = true;
        speed += 10;
        yield return new WaitForSeconds(0.3f);
        speed -= 10;
        yield return new WaitForSeconds(0.7f);
        isDashing = false;
    }

}
