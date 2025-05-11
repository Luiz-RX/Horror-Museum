using UnityEngine;
using UnityEngine.AI;

public class CavernicolaMiniBoss : MonoBehaviour
{
    public string roomName;
    public Transform player;
    public float chaseRange = 15f;
    public float stopDistance = 2f;
    public float attackCooldown = 2f;

    private NavMeshAgent agent;
    private Animator animator;

    [SerializeField]private bool canMove = false;
    [SerializeField]private bool playerInRoom = false;
    private int hitCount = 0;
    private bool isVulnerable = false;
    private bool isDead = false;
    private float lastAttackTime = -Mathf.Infinity;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead || isVulnerable || !canMove || !playerInRoom)
        {
            agent.isStopped = true;
            animator.SetBool("IsChasing", false);
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= stopDistance)
        {
            // Ataque si ha pasado suficiente tiempo
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
                agent.isStopped = true;
                animator.SetBool("IsChasing", false);
                animator.SetTrigger("IsAttacking");
            }
        }
        else if (distance <= chaseRange)
        {
            agent.SetDestination(player.position);
            agent.isStopped = false;
            animator.SetBool("IsChasing", true);
        }
        else
        {
            // Fuera de rango
            agent.isStopped = true;
            animator.SetBool("IsChasing", false);
        }
    }

    public void SetPlayerInRoom(bool state)
    {
        playerInRoom = state;
    }

    public void ActivateBoss()
    {
        canMove = true;
    }

    public void RegisterHit()
    {
        if (isDead) return;

        hitCount++;

        if (hitCount >= 3)
        {
            isVulnerable = true;
            animator.SetTrigger("Hit");
            Invoke(nameof(ResetVulnerability), 6f);
            hitCount = 0;
        }
    }

    void ResetVulnerability()
    {
        isVulnerable = false;
    }

    public void TryKillFromLamp()
    {
        if (isVulnerable && !isDead)
        {
            isDead = true;
            isVulnerable = false;
            animator.SetTrigger("Death");
            agent.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            RegisterHit();
        }
    }
}