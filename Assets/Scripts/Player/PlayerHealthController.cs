using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth=100;
    public int currentHealth;
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hpSlider.value = currentHealth;

    }
    private void OnEnable()
    {
        hpSlider.value = currentHealth;
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage( int dmg) 
    {
        currentHealth = currentHealth -= dmg;
        hpSlider.value = currentHealth;
    
    }
}
