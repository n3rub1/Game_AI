using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyBaseState
{

    Vector3[] destinationPoints = { 
        new Vector3(23.0f, 1.84f, 25.0f), 
        new Vector3(23.0f, 1.84f, -11.0f), 
        new Vector3(4.0f, 6.45f, -11f),
        new Vector3(-6.0f, 6.45f, 22.0f),
        new Vector3(-6.4f, 10.6f, 7.0f)
    };

    Vector3 destination;

    public override void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent)
    {
        int randomNumber = Random.Range(0, 5);
        destination = destinationPoints[randomNumber];
        navMeshAgent.speed = 10.0f;
    }

    public override void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player, Animator animator)
    {
        animator.SetBool("Run", true);
        animator.SetBool("Attack", false);

        navMeshAgent.destination = destination; 

        if(enemy.transform.position.x == destination.x)
        {
            enemy.SwitchState(enemy.enemyIdleState);
        }

        if(Vector3.Distance(player.transform.position, enemy.transform.position) < 5)
        {
            enemy.SwitchState(enemy.enemyAttackState);
        }
    }
}
