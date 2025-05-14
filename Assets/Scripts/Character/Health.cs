using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 6;

    public void TakeDamage(int damage)
    {
        if (health <= 0) 
        {
            //Morirse
        }
        health -= damage;
    }

    public int GiveHealth(int healthGiven)
    {
        return health =+ healthGiven;

    }
}
