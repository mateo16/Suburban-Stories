using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public static float currentHealth;
    public float maxHealth;
    public static HealthBar instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        healthBar.maxValue = maxHealth;
        if(FireBase.LoadHealth != 0)
        {
            healthBar.value = FireBase.LoadHealth;
            currentHealth = FireBase.LoadHealth;
        }
        else
        {
            healthBar.value = maxHealth;
            currentHealth = maxHealth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ReduceHealth(1);
        }
    }
    public void ReduceHealth(float amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;

        if(currentHealth <= 0)
        {
            transform.position = new Vector3(0, 3, -3);
            healthBar.value = maxHealth;
            currentHealth = maxHealth;
            FindObjectOfType<AudioManager>().Play("Death");
        }  
    }


}
