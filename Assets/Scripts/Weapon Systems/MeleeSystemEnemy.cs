using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystemEnemy : MonoBehaviour
{
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCooldown = 0.5f;
    public int damage = 1;
    public bool isAttacking = false;

    public GameObject enemyImpact;
    public Transform bloodPoint;

    public void SwordAttack()
    {
        isAttacking = true;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        Invoke("ResetAttack", AttackCooldown);
    }

    private void ResetAttack()
    {
        CanAttack = true;
        isAttacking = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && isAttacking)
        {
            other.GetComponent<HealthBar>().ReduceHealth(damage);
            Instantiate(enemyImpact, bloodPoint.position, bloodPoint.rotation);
            isAttacking = false;
        }
    }
}