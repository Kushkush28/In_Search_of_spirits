using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
       // gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        localScale.x =gameObject.GetComponentInParent<EnemyHPController>().currentHealth;
        if ( gameObject.GetComponentInParent<EnemyHPController>().currentHealth < gameObject.GetComponentInParent<EnemyHPController>().maxHealth) 
        {
            //gameObject.SetActive(true);
            transform.localScale = localScale;
        }
       

    }
}
