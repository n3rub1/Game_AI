using UnityEngine;
using UnityEngine.AI;

/*
    This class is used to control the player character and adjust their health
 */
public class PlayerController : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    AudioSource playerAudioSource;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Mathf.Abs(input.y) > 0.01f)
        {

            animator.SetBool("Run", true);
            Vector3 destination = transform.position + transform.right * input.x + transform.forward * input.y;
            navMeshAgent.destination = destination;
            if (!playerAudioSource.isPlaying)
            {
                playerAudioSource.Play();
            }
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

}
