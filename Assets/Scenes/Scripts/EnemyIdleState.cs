using UnityEngine;
using UnityEngine.AI;

/*
    This class is used to control the AI when it is in the Idle state. Enter state is like the Start() and UpdateState is like the Update() methods.
 */

public class EnemyIdleState : EnemyBaseState
{
    float idleCountDown;
    readonly int minimumDistanceFromPlayer = 8;
    public override void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent)
    {
        navMeshAgent.speed = 10.0f;
        idleCountDown = 3.0f;
    }

    public override void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player, Animator animator, AudioClip[] audioClip, PlayerHealth playerHealth)
    {

        animator.SetBool("Run", false);
        animator.SetBool("Attack", false);

        if (idleCountDown >= 0)
        {
            idleCountDown -= Time.deltaTime;
        }
        else
        {
            enemy.SwitchState(enemy.enemyPatrolState);
        }

        if (Vector3.Distance(player.transform.position, enemy.transform.position) < minimumDistanceFromPlayer)
        {
            enemy.SwitchState(enemy.enemyAttackState);
        }
    }
}
