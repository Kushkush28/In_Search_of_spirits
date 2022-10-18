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

    private bool facingRight;
    private int extraJumps;public int maxExtraJumps;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()

    {
        extraJumps = maxExtraJumps;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
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
            extraJumps = maxExtraJumps;
        }
        if (facingRight == true && moveInput > 0)
        {
            Flip();


        } else if (facingRight==false&&moveInput<0) 
        {
            Flip();
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
