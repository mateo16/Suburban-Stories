using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int health = 10;
    public int exp = 2;
    private ThiefAiScript thiefScript;
    private Experience expScript;

    private void Awake()
    {
        thiefScript = GetComponent<ThiefAiScript>();
        expScript = GameObject.FindWithTag("UI").GetComponent<Experience>();
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;

        if(health < 1)
        {
            if (thiefScript != null)
            {
                thiefScript.returnMoney();
            }

            expScript.UpdateExp(exp);
            FindObjectOfType<AudioManager>().Play("Death");
            Destroy(gameObject);
        }

    }


}
