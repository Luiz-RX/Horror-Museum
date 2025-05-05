using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    [SerializeField] private EnemyController[] enemies;

    public void ActivarEnemigos()
    {
        foreach (var enemy in enemies)
        {
            enemy.ActivarMovimiento();
        }
    }
}
