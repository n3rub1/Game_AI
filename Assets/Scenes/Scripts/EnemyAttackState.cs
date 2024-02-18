using UnityEngine;
using UnityEngine.AI;

/*
    This class is used to control the AI when it is in the Attack state. Enter state is like the Start() and UpdateState is like the Update() methods.
 */
public class EnemyAttackState : EnemyBaseState
{
    private float attackRange = 5.0f;
    private float attackSoundTimeLoop = 1.5f;
    readonly int minimumHealthForAttack = 5;
    public override void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent)
    {
        attackSoundTimeLoop = 0f;
    }

    public override void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player, Animator animator, AudioClip[] audioClip, PlayerHealth playerHealth)
    {

        animator.SetBool("Run", true);

        if (enemyHealth.health >= minimumHealthForAttack)
        {
            Vector3 directionToPlayer = (player.transform.position - enemy.transform.position).normalized;
            enemy.transform.position += directionToPlayer * navMeshAgent.speed * Time.deltaTime;
            enemy.transform.LookAt(player.transform.position);


            if (Vector3.Distance(enemy.transform.position, player.transform.position) <= attackRange)
            {
                animator.SetBool("Attack", true);
                AttackPlayer(audioClip, enemy, playerHealth, player);
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

    void AttackPlayer(AudioClip[] audioClip, EnemyStateManager enemy, PlayerHealth playerHealth, GameObject player)
    {

        if (attackSoundTimeLoop <= 0)
        {
            int randomAttackSound = Random.Range(0, 3);
            int randomHitSound = Random.Range(3, 6);
            AudioSource.PlayClipAtPoint(audioClip[randomAttackSound], enemy.transform.position);
            AudioSource.PlayClipAtPoint(audioClip[randomHitSound], player.transform.position);
            attackSoundTimeLoop = 1.5f;
            playerHealth.ReduceHealth();
        }
        else
        {
            attackSoundTimeLoop -= Time.deltaTime;
        }
    }

}
