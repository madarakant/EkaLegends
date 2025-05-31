using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 30;
    [SerializeField] private Collider weapon;
    private int currentHealth;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        DisableWeapons();
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public void EnableWeapons()
    {
        weapon.enabled = true;
    }

    public void DisableWeapons()
    {
        weapon.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("PlayerWeapon"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth >0)
        {
            print(currentHealth);
            anim.SetTrigger("Hit");
        }
        else
        {
            anim.SetTrigger("Dead");
        }
        
    }
}