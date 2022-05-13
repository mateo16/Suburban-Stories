using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public float currentHealth;
    public float maxHealth;
    public static HealthBar instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
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
}
