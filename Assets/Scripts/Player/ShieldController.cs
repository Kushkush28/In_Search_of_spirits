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
    private int playerHealth;    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shield.active) 
        {
           this.gameObject.GetComponent<PlayerHealthController>().currentHealth = playerHealth ;
        }
        if (Input.GetKeyDown(KeyCode.Q)&&isOnCoolDown==false) 
        { 
            ActivateShield();
        }
    }
    void ActivateShield() 
    {isOnCoolDown = true;
        shield.SetActive(true);
        this.gameObject.GetComponent<PlayerHealthController>().enabled = false;
        StartCoroutine(ActiveShield());
    }
    IEnumerator ActiveShield() 
    { 
    yield return new WaitForSeconds(activeTime);

    }
    IEnumerator CooldownShield()
    {   shield.SetActive(false);
        this.gameObject.GetComponent<PlayerHealthController>().enabled = true;
        playerHealth = this.gameObject.GetComponent<PlayerHealthController>().currentHealth;
        yield return new WaitForSeconds(cooldownTime);
        isOnCoolDown = false;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag=="EnemyProjectile") 
        {
            Destroy(other);
        }

    }
}
