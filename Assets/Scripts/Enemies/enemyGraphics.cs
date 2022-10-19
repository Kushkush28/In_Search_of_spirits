using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGraphics : MonoBehaviour
{
    public AIPath aiPath;
    public int knockbackForce = 10;
    public int enemyTouchDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);


        }
        else if (aiPath.desiredVelocity.x <=- 0.01f) 
        {
            transform.localScale = new Vector3(1f, 1f, 1f); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<ShieldController>() != null)
            {
                if (collision.gameObject.GetComponent<ShieldController>().shieldActive == true) { } else { collision.gameObject.GetComponent<PlayerHealthController>().TakeDamage(enemyTouchDamage); }


            }
            else { collision.gameObject.GetComponent<PlayerHealthController>().TakeDamage(enemyTouchDamage); }

        }
    }

}
