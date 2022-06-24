using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int health = 10;
    private ThiefAiScript thiefScript;
    private void Awake()
    {
        thiefScript = GetComponent<ThiefAiScript>();
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


                Destroy(gameObject);

               
                  
        }

    }


}
