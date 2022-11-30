using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public bool isGrounded;
    public Transform groundcheck;
    public float checkRadius = 0.7f;
    public LayerMask whatIsGround;
    public Animator animator;

    private bool facingRight;
    private int extraJumps;public int maxExtraJumps;
    public bool isJumping = false;

    private Rigidbody2D rb;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()

    {
        manager=FindObjectOfType<GameManager>();
        extraJumps = maxExtraJumps;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;

            extraJumps--;
            animator.SetBool("isJumping",true);
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJumps ==0 &&isGrounded==true) 
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity=new Vector2 (moveInput *speed,rb.velocity.y);

        if (isGrounded)
        {
            animator.SetBool("isFalling", false);
            isJumping = false;
            extraJumps = maxExtraJumps;
            animator.SetBool("isJumping", false);
        }

        if (!isGrounded &&isJumping==false) 
        {
            animator.SetBool("isFalling", true);
        }
        if (facingRight == true && moveInput > 0)
        {
            Flip();


        } else if (facingRight==false&&moveInput<0) 
        {
            Flip();
        }
        if (rb.velocity.magnitude==0)
        {
            animator.SetBool("isMoving", false);
        }
        else { animator.SetBool("isMoving", true); }
    }
    void Flip() 
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Dialogue") 
        {

            animator.SetBool("isMoving", false);
        }
        if (collision.tag=="Idol") 
        {
            manager.CollectIdol();
            Destroy(collision.gameObject);
        }
    }
}
