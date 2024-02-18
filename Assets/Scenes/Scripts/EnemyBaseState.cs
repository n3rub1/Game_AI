using UnityEngine;
using UnityEngine.AI;

/*
    This class is used as an abstract class, and all states inherit from it.
 */
public abstract class EnemyBaseState
{
    abstract public void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent);
    abstract public void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player, Animator animator, AudioClip[] audioClip, PlayerHealth playerHealth );

}
