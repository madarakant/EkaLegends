using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private float timeBetweenAttacks = 2;
    
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private Animator animator;
    private float lastAttackTime = 0;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (enemyHealth.IsDead())
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("run", navMeshAgent.velocity.magnitude > 0.5f);
            navMeshAgent.SetDestination(target.position);
            
            if(Vector3.Distance(transform.position, target.position) < 2.2f)
            {
                if (Time.time > lastAttackTime + timeBetweenAttacks)
                {
                    animator.SetTrigger("attack");
                    lastAttackTime = Time.time;
                }
            }
        }
      
    }
}