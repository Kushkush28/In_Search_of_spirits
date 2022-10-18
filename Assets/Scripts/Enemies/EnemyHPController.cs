using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPController : MonoBehaviour
{ public int maxHealth=100;
    public int currentHealth;
    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg) 
    {
        currentHealth -= dmg;
        DeathCheck();
    
    }
    void DeathCheck() 
    {
        if (currentHealth<=0) 
        {
            if (deathEffect != null)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                
            }
            Destroy(gameObject);
        }


    }
}
