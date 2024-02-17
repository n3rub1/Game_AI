using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{

    EnemyBaseState currentState;
    NavMeshAgent navMeshAgent;
    EnemyHealth enemyHealth;
    Animator animator;
    public GameObject player;
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    public EnemyRunAwayState enemyRunAwayState = new EnemyRunAwayState();
    public EnemyPatrolState enemyPatrolState = new EnemyPatrolState();
    public EnemyIdleState enemyIdleState = new EnemyIdleState();


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        currentState = enemyIdleState;
        currentState.EnterState(this, navMeshAgent);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this, navMeshAgent, enemyHealth, player, animator);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this, navMeshAgent);
    }


}
