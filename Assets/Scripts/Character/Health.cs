using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 6;
    private Animator animator;
    private CharacterController characterController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        characterController.enabled = true;
        animator.SetBool("Die", false);
    }
    public void TakeDamage(int damage)
    {
        if (health <= 0) 
        {
            animator.SetBool("Die", true);
            characterController.enabled = false;
        }
        health -= damage;
    }

    public int GiveHealth(int healthGiven)
    {
        return health =+ healthGiven;

    }
}
