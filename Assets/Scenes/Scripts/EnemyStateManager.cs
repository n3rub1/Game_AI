using UnityEngine;
using UnityEngine.AI;

/*
    This class is used to control the finite state machine, by updating and switching states
 */

public class EnemyStateManager : MonoBehaviour
{

    EnemyBaseState currentState;
    NavMeshAgent navMeshAgent;
    EnemyHealth enemyHealth;
    Animator animator;
    public PlayerHealth playerHealth;
    public AudioClip[] audioClips;
    public GameObject player;
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    public EnemyRunAwayState enemyRunAwayState = new EnemyRunAwayState();
    public EnemyPatrolState enemyPatrolState = new EnemyPatrolState();
    public EnemyIdleState enemyIdleState = new EnemyIdleState();


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        currentState = enemyIdleState;
        currentState.EnterState(this, navMeshAgent);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this, navMeshAgent, enemyHealth, player, animator, audioClips, playerHealth);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this, navMeshAgent);
    }

}
