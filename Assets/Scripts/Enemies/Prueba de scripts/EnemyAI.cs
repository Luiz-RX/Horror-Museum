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
    bool isDead;
    int hitCount = 0;

    [SerializeField] private bool playerInRoom = false;

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
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;

        if (!canMove || !playerInRoom)
        {
            ReturnToStart();
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            agent.isStopped = true;
            animator.SetTrigger("Attacking");
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("IsWalking", true);
        }
    }

    public void RegisterHit()
    {
        if (isDead) return;

        hitCount++;

        if (hitCount >= 4)
        {
           
            animator.SetBool("Die", true);
            
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            RegisterHit();
        }
    }

    private void ReturnToStart()
    {
        float distToStart = Vector3.Distance(transform.position, startPosition);
        if (distToStart > 0.1f)
        {
            agent.isStopped = false;
            agent.SetDestination(startPosition);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("IsWalking", false);
        }
    }

    // Llamado por RoomManager o Trigger
    public void SetPlayerInRoom(bool inRoom)
    {
        playerInRoom = inRoom;
    }
}
