using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxHealth;

    public float currentHealth;

    public float speed;

    private bool bLive;

    public Transform target;

    private Rigidbody rigid;

    private Animator animator;

    private NavMeshAgent nav;


    private void Start()
    {
        rigid = this.GetComponent<Rigidbody>();

        animator = this.GetComponent<Animator>();

        nav = this.GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        maxHealth = currentHealth;

        bLive = true;

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Chase();
    }

    private void FixedUpdate()
    {
        if(!bLive)
        {
            return;
        }
    }

    private void Chase()
    {
        nav.SetDestination(target.position);

        animator.SetBool("bMove", true);
    }
}
