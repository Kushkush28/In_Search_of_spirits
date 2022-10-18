using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    [Header("Player variables")]
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    [Header("Mouse & Aim")]
    Vector2 mousePos;


    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal"); //get movement input
      //  movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);// move player
        Vector2 lookDirection = mousePos - rb.position;
      //  float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;//get angle to rotate to reach the mouse
        //rb.rotation = angle;
    }
}
