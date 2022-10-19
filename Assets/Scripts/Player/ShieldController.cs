using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public GameObject shield;
    public float cooldownTime=5f;
    public float activeTime=5f;
    private float cooldowncOUNTER;
    public bool isOnCoolDown = false;
    public bool shieldActive;
    private int playerHealth;    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shield.activeInHierarchy==true) 
        {
            this.gameObject.GetComponent<PlayerHealthController>().currentHealth = this.gameObject.GetComponent<PlayerHealthController>().maxHealth;
        }
        if (Input.GetKeyDown(KeyCode.Q)&&isOnCoolDown==false) 
        { 
            ActivateShield();
            playerHealth = this.gameObject.GetComponent<PlayerHealthController>().currentHealth;
        }
    }
    void ActivateShield() 
    {isOnCoolDown = true;
        this.gameObject.GetComponent<PlayerHealthController>().currentHealth = this.gameObject.GetComponent<PlayerHealthController>().maxHealth;
        shield.SetActive(true);
        this.gameObject.GetComponent<PlayerHealthController>().enabled = false;
        shieldActive = true;
        StartCoroutine(ActiveShield());
    }
    IEnumerator ActiveShield() 
    { 
    yield return new WaitForSeconds(activeTime);
        shieldActive = false;
        StartCoroutine(CooldownShield());

       // playerHealth = this.gameObject.GetComponent<PlayerHealthController>().currentHealth;
    }
    IEnumerator CooldownShield()
    {   
        shield.SetActive(false);
        this.gameObject.GetComponent<PlayerHealthController>().enabled = true;
        isOnCoolDown = false;
        yield return new WaitForSeconds(cooldownTime);
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag=="EnemyProjectile") 
        {
            Destroy(other);
        }

    }
}
