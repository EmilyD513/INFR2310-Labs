using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavControl : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;
    bool isWalking = true;
    private Animator animator;
    public float speed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.speed = agent.speed - 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
            agent.destination = Target.transform.position;
        else
        {
            agent.destination = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dragon")
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");
            animator.speed = 1.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
            animator.speed = agent.speed - 2.0f;
        }
    }
}
