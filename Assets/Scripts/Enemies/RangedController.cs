using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedController : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject enemyProjectile;
        public GameObject projectileSpawnPoint;
    private Transform player;
    public float enemyRange = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,player.position)<enemyRange) 
        {
            if (timeBtwShots <= 0)
            { Instantiate(enemyProjectile, projectileSpawnPoint.transform.position, Quaternion.identity);
               
                timeBtwShots = startTimeBtwShots;
            }
            else { timeBtwShots -= Time.deltaTime; }
        }
    }
}
