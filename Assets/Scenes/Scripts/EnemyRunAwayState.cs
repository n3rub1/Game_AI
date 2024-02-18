using UnityEngine;
using UnityEngine.AI;

/*
    This class is used to control the AI when it is in the RunAway state. Enter state is like the Start() and UpdateState is like the Update() methods.
 */
public class EnemyRunAwayState : EnemyBaseState
{
    float healTime = 1.0f;
    bool runningAway = false;
    Vector3 runAwayDestination = new Vector3(-6.4f, 10.6f, 7.0f);
    readonly float[] enemyOnLowGround = { 0.8f, 2.0f };
    readonly float[] enemyOnMiddleGround = { 4.0f, 6.0f };
    readonly float[] enemyOnHighGround = { 8.5f };

    Vector3[] destinationPoints = {
        new Vector3(23.0f, 1.84f, 25.0f),
        new Vector3(23.0f, 1.84f, -11.0f),
        new Vector3(4.0f, 6.45f, -11f),
        new Vector3(-6.0f, 6.45f, 22.0f),
        new Vector3(-6.4f, 10.6f, 7.0f)
    };

    public override void EnterState(EnemyStateManager enemy, NavMeshAgent navMeshAgent)
    {
        navMeshAgent.speed = 15.0f;
        healTime = 1.0f;
        runningAway = false;
    }

    public override void UpdateState(EnemyStateManager enemy, NavMeshAgent navMeshAgent, EnemyHealth enemyHealth, GameObject player, Animator animator, AudioClip[] audioClip, PlayerHealth playerHealth)
    {
        animator.SetBool("Run", true);
        animator.SetBool("Attack", false);
        if (enemyHealth.health == 10)
        {
            enemy.SwitchState(enemy.enemyPatrolState);
            runningAway = false;
        }
        else
        {
            healTime -= Time.deltaTime;

            if (enemy.transform.position.y > enemyOnLowGround[0] && enemy.transform.position.y < enemyOnLowGround[1] && !runningAway)
            {
                runningAway = true;
                runAwayDestination = destinationPoints[4];
            }
            else if (enemy.transform.position.y > enemyOnMiddleGround[0] && enemy.transform.position.y < enemyOnMiddleGround[1] && !runningAway)
            {
                runningAway = true;
                runAwayDestination = destinationPoints[0];
            }
            else if (enemy.transform.position.y > enemyOnHighGround[0] && !runningAway)
            {
                runningAway = true;
                runAwayDestination = destinationPoints[1];
            }

            navMeshAgent.destination = runAwayDestination;

            if (healTime <= 0)
            {
                enemyHealth.IncreaseHealth();
                healTime = 1.0f;
            }
        }
    }
}
