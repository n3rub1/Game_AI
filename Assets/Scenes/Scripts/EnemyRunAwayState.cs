using UnityEngine;
using UnityEngine.AI;

public class EnemyRunAwayState : EnemyBaseState
{
    Vector3[] destinationPoints = {
        new Vector3(23.0f, 1.84f, 25.0f),
        new Vector3(23.0f, 1.84f, -11.0f),
        new Vector3(4.0f, 6.45f, -11f),
        new Vector3(-6.0f, 6.45f, 22.0f),
        new Vector3(-6.4f, 10.6f, 7.0f)
    };
    float healTime; 

    public override void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent)
    {
        Debug.Log("Run away!");
        navMeshAgent.speed = 15.0f;
        healTime = 1.0f;
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider collider)
    {

    }
    public override void onTriggerExit(EnemyStateManager enemy, Collider collider)
    {
    }

    public override void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player)
    {

        if(enemyHealth.health == 10)
        {
            enemy.SwitchState(enemy.enemyPatrolState);
        }
        else
        {
            healTime -= Time.deltaTime;
            Vector3 vector3 = destinationPoints[4];
            navMeshAgent.destination = vector3;

            if(healTime <= 0)
            {
                enemyHealth.IncreaseHealth();
                healTime = 1.0f;
            }
        }
    }
}
