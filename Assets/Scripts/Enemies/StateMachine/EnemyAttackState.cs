using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float stopAttackingDistance = 2.5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance > stopAttackingDistance)
        {
            animator.SetBool("isAttacking", false);
        }

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.position - agent.transform.position;
        direction.y = 0;
        if (direction != Vector3.zero)
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.LookRotation(direction), 0.2f);
    }
}