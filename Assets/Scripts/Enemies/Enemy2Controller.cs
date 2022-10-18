using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    [Header("Enemy properties")]
    
    public Transform player;
    public Transform firePoint;
    public int range=10;

    [Header("Weapon properties")]
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;
    public float bulletForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = transform.position - player.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
        //this.gameObject.GetComponent<Rigidbody2D>().rotation = angle;

        if (Vector2.Distance(transform.position,player.position)<=range) 
        {
            if (timeBetweenShots <= 0)
            {
                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(-lookDirection* bulletForce, ForceMode2D.Impulse);
                timeBetweenShots = startTimeBetweenShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }

        }
       

    }
}
