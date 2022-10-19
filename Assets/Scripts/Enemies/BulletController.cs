using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    public float lifeTime =2f;
    public int bulletDamage = 10;

    public GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void DestroyProjectile()
    {
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            if (collision.gameObject.GetComponent<ShieldController>() != null)
            {
                if (collision.gameObject.GetComponent<ShieldController>().shieldActive == true) { } else { collision.gameObject.GetComponent<PlayerHealthController>().TakeDamage(bulletDamage); }


            }
            else { collision.gameObject.GetComponent<PlayerHealthController>().TakeDamage(bulletDamage); }
        }
        Destroy(gameObject);
    }
}
