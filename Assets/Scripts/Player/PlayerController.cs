using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Variables")]
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool isRightFacing = true;
    public Transform groundCheck;
    public float groundCheckRadius=1f;
    private bool isGrounded;
    public LayerMask whatIsGround;
   private int extraJumps;
    public int extraJumpValue=3;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded) 
        {
            extraJumps = extraJumpValue;
        } 

        if (Input.GetKeyDown(KeyCode.Space)&& extraJumps>0) 
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.AddForce(Vector2.up * jumpForce);
            extraJumps--;
        }
        if (Input.GetKey(KeyCode.Space)&& extraJumps==0 &&isGrounded==true) 
        {
            rb.AddForce(Vector2.up*jumpForce);
            
        }
        if (Input.GetKey(KeyCode.Space)) 
           {
            if (jumpTimeCounter>0)
            {
                rb.AddForce(Vector2.up * jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            
           }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            isJumping = false;
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed , rb.velocity.y);
        if (isRightFacing == false && moveInput > 0)
        {
            FlipPlayerDirection();

        } else if (isRightFacing==true && moveInput<0) 
        {
            FlipPlayerDirection();
        }
        
    }
    void FlipPlayerDirection() 
    {
        isRightFacing = !isRightFacing;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        
    }

}
