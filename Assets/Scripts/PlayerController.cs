using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    public float speed = 3f;
    public float jumpForce = 10f;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;


    private bool isGrounded;
    private Transform groundCheck;
    private float checkRadius = 0.5f;
    private LayerMask whatIsGroud;
    public Animator animator;

    public GroundedCheck GroundCheck;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //groundCheck = transform.Find("GroundCheck");
       //whatIsGroud = LayerMask.GetMask("Plataforms");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //isGrounded = false;

        /*Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, checkRadius, whatIsGroud);
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log("whhat");
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
                
        }
        */
        isGrounded = GroundCheck.isGrounded;
        animator.SetBool("grounded", isGrounded);
        moveInput = CrossPlatformInputManager.GetAxis("Horizontal");
        if (animator)
        {
            if (moveInput == 0)
            {
                animator.SetBool("Walking", false);
            }
            else
            {
                animator.SetBool("Walking", true);
            }
        }
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        } else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
