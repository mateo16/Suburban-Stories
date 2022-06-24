using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour
{
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCooldown = 0.5f;
    public int damage = 1;
    public bool isAttacking = false;

    public GameObject enemyImpact;
    public Transform bloodPoint;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && CanAttack)
        {
            SwordAttack();
            FindObjectOfType<AudioManager>().Play("Gunshot");
        }
    }
    public void SwordAttack()
    {
        isAttacking = true;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        Invoke("ResetAttack",AttackCooldown);
    }

    private void ResetAttack()
    {
        CanAttack = true;
        isAttacking = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy" && isAttacking)
        {
            other.GetComponent<EnemyDamage>().TakeDamage(damage);
            Instantiate(enemyImpact, bloodPoint.position, bloodPoint.rotation);
            isAttacking = false;
        }
    }
}

