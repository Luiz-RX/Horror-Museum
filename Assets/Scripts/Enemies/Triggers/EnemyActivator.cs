using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    EnemyManager m_EnemyManager;

    private void Start()
    {
        m_EnemyManager = FindAnyObjectByType<EnemyManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        m_EnemyManager.ActivateMovement();
    }
}
