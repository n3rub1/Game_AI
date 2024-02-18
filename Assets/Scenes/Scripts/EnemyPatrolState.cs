using UnityEngine;
using UnityEngine.AI;

/*
    This class is used to control the AI when it is in the Patrol state, following pre-determined routes. 
    Enter state is like the Start() and UpdateState is like the Update() methods.
 */

public class EnemyPatrolState : EnemyBaseState
{
    readonly float enemySpeed = 10.0f;
    readonly int minimumDistanceFromPlayer = 8;

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
        int randomNumber = Random.Range(0, destinationPoints.Length);
        destination = destinationPoints[randomNumber];
        navMeshAgent.speed = enemySpeed;
    }

    public override void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player, Animator animator, AudioClip[] audioClip, PlayerHealth playerHealth)
    {
        animator.SetBool("Run", true);
        animator.SetBool("Attack", false);

        navMeshAgent.destination = destination;

        if (enemy.transform.position.x == destination.x)
        {
            enemy.SwitchState(enemy.enemyIdleState);
        }

        if (Vector3.Distance(player.transform.position, enemy.transform.position) < minimumDistanceFromPlayer)
        {
            enemy.SwitchState(enemy.enemyAttackState);
        }
    }
}
