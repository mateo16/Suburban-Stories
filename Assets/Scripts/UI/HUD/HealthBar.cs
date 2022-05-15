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
        Debug.Log(FireBase.LoadHealth);
        if(FireBase.LoadHealth != 0)
        {
            Debug.Log("funca");
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
    void ReduceHealth(float amount)
    {
            currentHealth -= amount;
            healthBar.value = currentHealth; 
    }

    public void aLoadHealth(float amount)
    {
        currentHealth = amount;

    }
}
