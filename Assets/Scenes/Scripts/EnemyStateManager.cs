using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{

    EnemyBaseState currentState;
    NavMeshAgent navMeshAgent;
    EnemyHealth enemyHealth;
    public GameObject player;
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    public EnemyRunAwayState enemyRunAwayState = new EnemyRunAwayState();
    public EnemyPatrolState enemyPatrolState = new EnemyPatrolState();
    public EnemyIdleState enemyIdleState = new EnemyIdleState();


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        currentState = enemyIdleState;
        currentState.EnterState(this, navMeshAgent);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this, navMeshAgent, enemyHealth, player);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this, navMeshAgent);
    }

    public void OnTriggerEnter(Collider collider)
    {
        currentState.OnTriggerEnter(this, collider);
    }

    private void OnTriggerExit(Collider collider)
    {
        currentState.onTriggerExit(this, collider);
    }

}
