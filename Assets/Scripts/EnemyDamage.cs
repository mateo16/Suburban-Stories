using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int health = 10;
    public Transform playerTransform;
    public float speed = 0f;
    public float id = 1;
    Vector3 firstPos;
    public GameObject prefabSphere;
    void Start()
    {
        firstPos = transform.position;
    }

    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
        }
        CheckIfEnemyIsFalling();
        Detection();
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
    }

        void MeasureDistance()
    {
        float dist = Vector3.Distance(playerTransform.position, transform.position);
        Debug.Log("Distancia = " + dist);
    }

        void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    void Respawn()
    {
        transform.position = firstPos;
    }

    void CheckIfEnemyIsFalling()
    {
        if(transform.position.y < -20)
        {
            Respawn();
        }
    }

    void Detection()
    {
        if(Vector3.Distance(playerTransform.position, transform.position) < 50)
            {
                speed = 1;
                MoveTowardsPlayer();
            }
    }
}
