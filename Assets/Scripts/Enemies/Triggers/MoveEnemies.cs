using UnityEngine;

public class MoveEnemies : MonoBehaviour
{
    public MeleeEnemy[] enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].move = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].move = false;
            }
        }
    }
}
