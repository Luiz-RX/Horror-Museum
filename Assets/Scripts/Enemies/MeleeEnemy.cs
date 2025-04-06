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
        if (move)
        {
            MoveToTarget();
        } else
        {
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

    

}
