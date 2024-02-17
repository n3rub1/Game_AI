using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBaseState
{
    abstract public void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent);
    abstract public void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player, Animator animator);

}
