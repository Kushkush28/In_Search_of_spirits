using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{  public float bulletSpeed = 20f;
    public float lifeTime = 5f;

    public GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile",lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyProjectile() 
    {
        if (destroyEffect!=null)
        {
            Instantiate(destroyEffect,transform.position,Quaternion.identity);
        }
        Destroy(gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag=="Enemy") 
        { 
        }
        if (collision.gameObject.tag!="Player") 
        
        {
            Destroy(gameObject);
        }
        
    }
}
