using UnityEngine;

public class Sarcofago : MonoBehaviour
{
    private Animation m_animation;
    [SerializeField] bool hasEnemy;
    private bool playerIn;
    private Inventarioimprovisado inventario;

    private EnemyAI enemyAI;
    private CapsuleCollider capsuleCollider;

    private void Start()
    {
        m_animation = GetComponent<Animation>();
        if (hasEnemy)
        {
            enemyAI = GetComponentInChildren<EnemyAI>();
        }
        else if (!hasEnemy)
        {
            capsuleCollider = GetComponentInChildren<CapsuleCollider>();
            
        }
    }
    private void Update()
    {
        if (playerIn && Input.GetKeyDown(KeyCode.E))
        {
            if (inventario.palanca == true)
            {
                m_animation.Play();
                if (hasEnemy)
                {
                    //Activar al enemigo
                } else if (!hasEnemy)
                {
                    capsuleCollider.enabled = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIn = true;
            inventario = other.GetComponent<Inventarioimprovisado>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIn = false;
        }
    }
}
