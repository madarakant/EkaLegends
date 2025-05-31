using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int startingHealth = 100;
    [SerializeField] private float timeBetweenHits = 1f;
    [SerializeField] private Collider[] weapons;
    
    private int _currentHealth;
    private int _currentMaxHealth;
    private float lastHitTime = 0;
    private Animator animator;
    
    public static bool isAlive = true;
    
    public int CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            if (value < 0)
                _currentHealth = 0;
            else
                _currentHealth = value;
        }
    }

    public void EnableWeapon()
    {
        foreach (Collider weapon in weapons)
            weapon.enabled = true;
    }

    public void DisableWeapon()
    {
        foreach (Collider weapon in weapons)
            weapon.enabled = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(("EnemyWeapon")) && Time.time - lastHitTime > timeBetweenHits)
        {
            TakeDamage(5);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _currentHealth = startingHealth;
        _currentMaxHealth = startingHealth;
        isAlive = true;
        DisableWeapon();
    }

    public float GetHealthRatio()
    {
        return (float)_currentHealth / (float)_currentMaxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        lastHitTime = Time.time;
        _currentHealth -= damage;
        Debug.Log("Current health " + _currentHealth);
        if(_currentHealth > 0)
            animator.SetTrigger("IsHurt");
        else
        {
            animator.SetBool("IsDead", true);
            isAlive = false;
        }
    }
}
