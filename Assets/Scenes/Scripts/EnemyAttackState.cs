using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : EnemyBaseState
{
    private float attackRange = 5.0f;
    public override void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent)
    {

        Debug.Log("ATTACK!");
    }

    public override void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player, Animator animator)
    {

        animator.SetBool("Run", true);

        if (enemyHealth.health >= 5)
        {
            Vector3 directionToPlayer = (player.transform.position - enemy.transform.position).normalized;
            enemy.transform.position += directionToPlayer * navMeshAgent.speed * Time.deltaTime;
            enemy.transform.LookAt(player.transform.position);


            if(Vector3.Distance(enemy.transform.position, player.transform.position) <= attackRange)
            {
                animator.SetBool("Attack", true);
                AttackPlayer();
            }
            else
            {
                animator.SetBool("Attack", false);
                enemy.SwitchState(enemy.enemyPatrolState);
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            enemy.SwitchState(enemy.enemyRunAwayState);
        }

    }

    void AttackPlayer()
    {
        Debug.Log("Take this!");
    }
}
