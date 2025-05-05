using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Transform roomCenter;
    public float roomRadius = 10f;
    public float attackRange = 2f;

    private NavMeshAgent agent;
    private Animator animator;
    private bool moverse = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!moverse || player == null) return;

        float distanceToRoomCenter = Vector3.Distance(player.position, roomCenter.position);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToRoomCenter <= roomRadius)
        {
            animator.SetBool("isChasing", true);
            agent.SetDestination(player.position);

            if (distanceToPlayer <= attackRange)
            {
                animator.SetBool("isAttacking", true);
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }
        else
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isAttacking", false);
            agent.ResetPath();
        }
    }

    public void ActivarMovimiento()
    {
        moverse = true;
        animator.SetBool("moverse", true);
    }
}
