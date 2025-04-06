using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0) 
            {
                EnemyDie();
            }
        }
    }

    void EnemyDie()
    {

    }
}
