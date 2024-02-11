using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : EnemyBaseState
{
    private float attackRange = 1.0f;
    public override void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent)
    {

        Debug.Log("ATTACK!");
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {

    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider collider)
    {
        
    }
    public override void onTriggerExit(EnemyStateManager enemy, Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.CompareTag("Player"))
        {
            enemy.SwitchState(enemy.enemyPatrolState);
        }
    }

    public override void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player)
    {


        if (enemyHealth.health >= 5)
        {
            Vector3 directionToPlayer = (player.transform.position - enemy.transform.position).normalized;
            enemy.transform.position += directionToPlayer * navMeshAgent.speed * Time.deltaTime;
            enemy.transform.LookAt(player.transform.position);

            if(Vector3.Distance(enemy.transform.position, player.transform.position) <= attackRange)
            {
                AttackPlayer();
            }
        }
        else
        {
            enemy.SwitchState(enemy.enemyRunAwayState);
        }

    }

    void AttackPlayer()
    {
        Debug.Log("Take this!");
    }
}
