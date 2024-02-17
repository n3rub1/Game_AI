using UnityEngine;
using UnityEngine.AI;

public class EnemyIdleState : EnemyBaseState
{
    float idleCountDown;
    public override void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent)
    {
        navMeshAgent.speed = 10.0f;
        idleCountDown = 3.0f;
    }

    public override void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player, Animator animator)
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

        if (Vector3.Distance(player.transform.position, enemy.transform.position) < 5)
        {
            enemy.SwitchState(enemy.enemyAttackState);
        }
    }
}
