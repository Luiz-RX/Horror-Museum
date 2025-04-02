using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : EnemyBase
{
    private NavMeshAgent navMesh;
    private Animator animator;
    private Transform player;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = FindAnyObjectByType<PlayerMovement>().transform;

    }

    private void Update()
    {
        if (move)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        navMesh.speed = speed;
        navMesh.SetDestination(player.position);
    }

}
