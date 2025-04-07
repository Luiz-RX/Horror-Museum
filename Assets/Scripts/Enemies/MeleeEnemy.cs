using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : EnemyBase
{
    private NavMeshAgent navMesh;
    private Animator animator;
    private Transform player;

    private Vector3 initialPos;

    [SerializeField] float attackRange, timeBetweenAttacks;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = FindAnyObjectByType<PlayerMovement>().transform;
        
        initialPos = this.transform.position;
    }

    private void Update()
    {
        if (navMesh.velocity == Vector3.zero)
        {
            animator.SetBool("Walking", false);
        } else
        {
            animator.SetBool("Walking", true);
        }
        float distanceToPlayer = Vector3.Distance(player.position, this.transform.position);
        if (move && distanceToPlayer > attackRange)
        {
            MoveToTarget();
        } else if (move && distanceToPlayer < attackRange)
        {
            Attack();
        }else {
            if(this.transform.position != initialPos)
            {
                navMesh.speed = 2;
                navMesh.SetDestination(initialPos);
            }
        }
    }

    private void MoveToTarget()
    {
        navMesh.speed = speed;
        navMesh.SetDestination(player.position);
    }

    void Attack()
    {
        navMesh.speed = 0;
        animator.SetTrigger("Attack");
    }

    void ResetSpeed()
    {
        navMesh.speed = speed;
    }

    

}
