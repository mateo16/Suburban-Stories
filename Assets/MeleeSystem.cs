using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour
{
    bool attacking;
    public Animator anim;

    void Start()
    {
        MyInput();
        anim = GetComponent<Animator>();
    }

        private void MyInput()
    {
        attacking = Input.GetKey(KeyCode.Mouse0);

        if(/*readyToShoot &&*/ attacking)
        {
            Attack();
        }
    }

    void Update()
    {
        
    }

    void Attack(){
        anim.SetBool("IsAttacking", true);
    }
}
