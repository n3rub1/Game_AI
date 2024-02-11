using UnityEngine;
using UnityEngine.AI;

public class EnemyIdleState : EnemyBaseState
{
    float idleCountDown;
    public override void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent)
    {
        Debug.Log("Idling around...");
        navMeshAgent.speed = 10.0f;
        idleCountDown = 3.0f;
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        /*        GameObject other = collision.gameObject;
                if (other.CompareTag("Player"))
                {
                    Debug.Log("collision from idle");
                    enemy.SwitchState(enemy.enemyAttackState);
                }*/
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.CompareTag("Player"))
        {
            enemy.SwitchState(enemy.enemyAttackState);
        }
    }
    public override void onTriggerExit(EnemyStateManager enemy, Collider collider)
    {
    }

    public override void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player)
    {
        if (idleCountDown >= 0)
        {
            idleCountDown -= Time.deltaTime;
        }
        else
        {
            enemy.SwitchState(enemy.enemyPatrolState);
        }
    }
}
