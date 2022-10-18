using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public float bulletForce = 20f;
    Vector2 mousePos; public Camera cam;

      public Rigidbody2D rb;
    private void Start()
    {
        timeBetweenShots = startTimeBetweenShots;
    }
    void Update()
    {
        rb.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButton("Fire1"))
        {
            if (timeBetweenShots <= 0)
            {
                Shoot();
                timeBetweenShots = startTimeBetweenShots;

            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }

    }
    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePos - rb.position;
          float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;//get angle to rotate to reach the mouse
        gameObject.GetComponent<Rigidbody2D>().rotation = angle;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //create bullet in scene
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);//fire bullet forward toward mouse.
    }
}
