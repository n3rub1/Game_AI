using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(Mathf.Abs(input.y) > 0.01f)
        {

            animator.SetBool("Run", true);
            Vector3 destination = transform.position + transform.right * input.x + transform.forward * input.y;
            navMeshAgent.destination = destination;
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
