using UnityEngine;

public class Sarcofago : MonoBehaviour
{
    private Animation m_animation;
    [SerializeField] bool hasEnemy;
    private bool playerIn;
    private Inventarioimprovisado inventario;
    [SerializeField] InventoryObject inventory;
    [SerializeField] AudioClip openSound;

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
            for(int i = 0; i < inventory.Container.Count; i++)
            {
                if (inventory.Container[i].item.name == "Crowbar")
                {
                    SoundFXManager.Instance.PlaySoundFXClip(openSound, this.transform, 1f);
                    m_animation.Play();
                    if (hasEnemy)
                    {
                        //Activar al enemigo
                    }
                    else if (!hasEnemy)
                    {
                        capsuleCollider.enabled = true;
                    }
                }
            }

            //if (inventario.palanca == true)
            //{
            //    m_animation.Play();
            //    if (hasEnemy)
            //    {
            //        //Activar al enemigo
            //    } else if (!hasEnemy)
            //    {
            //        capsuleCollider.enabled = true;
            //    }
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = true;
            inventario = other.GetComponent<Inventarioimprovisado>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
        }
    }
}
