using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Health playerHealth;
    [SerializeField] private int damage;
    

    private void Start()
    {
        playerHealth = FindAnyObjectByType<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Te meto");
        Damage(damage);
    }
    
    private void Damage(int num)
    {

        playerHealth.TakeDamage(num);
    }
}
