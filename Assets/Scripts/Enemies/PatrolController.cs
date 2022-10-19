using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform foot;
    public float distance;
    private Rigidbody2D rb;
    public int touchDamage=10;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
    transform.Translate(Vector2.right*speed*Time.deltaTime);
        //rb.velocity= Vector2.right*speed;
        RaycastHit2D groundInfo = Physics2D.Raycast(foot.position,Vector2.down,distance);
        RaycastHit2D wallInfo = Physics2D.Raycast(foot.position,Vector2.right,distance);

        if (groundInfo.collider==false||(wallInfo.collider==true)) 
        {
            if (movingRight == true)
            {
                
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else {
                
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthController>().TakeDamage(touchDamage);
        }
    }
}
