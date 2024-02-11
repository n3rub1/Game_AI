using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBaseState
{
    abstract public void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent);
    abstract public void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player);
    abstract public void OnCollisionEnter(EnemyStateManager enemy, Collision collision);
    abstract public void OnTriggerEnter(EnemyStateManager enemy, Collider collider);
    abstract public void onTriggerExit(EnemyStateManager enemy, Collider collider);
}
