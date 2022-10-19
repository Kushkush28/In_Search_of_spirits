using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
    public Slider slider;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = enemy.GetComponent<EnemyHPController>().maxHealth;
        slider.value = slider.maxValue;
        slider.gameObject.SetActive(false);
       // gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
     //   localScale.x =gameObject.GetComponentInParent<EnemyHPController>().currentHealth;
        if ( enemy.GetComponent<EnemyHPController>().currentHealth < enemy.GetComponentInParent<EnemyHPController>().maxHealth) 
        {
           slider.gameObject.SetActive(true);
            slider.value = enemy.GetComponent<EnemyHPController>().currentHealth;
            //  transform.localScale = localScale;
        }
       

    }
}
