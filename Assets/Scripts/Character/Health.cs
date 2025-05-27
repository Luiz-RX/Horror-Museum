using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 6;
    private Animator animator;
    private CharacterController characterController;
    public bool isDead;
    public GameObject deathUI;

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
            isDead = true;
            deathUI.SetActive(true);
        }
        health -= damage;
    }

    public int GiveHealth(int healthGiven)
    {
        return health =+ healthGiven;

    }
}
