using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth=100;
    public int currentHealth;
    public Slider hpSlider;

    public Image overlay;
    public float duration;
    public float fadeSpeed;
    public float durationTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hpSlider.value = currentHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);

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
        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
        if (currentHealth<0 ) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        }
    }

    public void TakeDamage( int dmg) 
    {
        currentHealth = currentHealth -= dmg;
        hpSlider.value = currentHealth;
  
        durationTimer = 0f;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1f);
    }
}
