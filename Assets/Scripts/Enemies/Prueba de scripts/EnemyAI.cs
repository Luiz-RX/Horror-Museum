using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool canMove = false;
    public string roomName;
    public float attackRange = 2f;

    private Vector3 startPosition;
    private NavMeshAgent agent;
    private Transform player;
    private Animator animator;

    private bool playerInRoom = false;

    private void Start()
    {
        startPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyManager.Instance.RegisterEnemy(this);
    }

    private void Update()
    {
        if (!canMove || !playerInRoom)
        {
            ReturnToStart();
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            agent.isStopped = true;
            animator.Play("Attack"); 
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.Play("Walk"); 
        }
    }

    private void ReturnToStart()
    {
        float distToStart = Vector3.Distance(transform.position, startPosition);
        if (distToStart > 0.1f)
        {
            agent.isStopped = false;
            agent.SetDestination(startPosition);
            animator.Play("Walk");
        }
        else
        {
            agent.isStopped = true;
            animator.Play("Idle");
        }
    }

    // Llamado por RoomManager o Trigger
    public void SetPlayerInRoom(bool inRoom)
    {
        playerInRoom = inRoom;
    }
}
