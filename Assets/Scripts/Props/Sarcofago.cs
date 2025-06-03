using UnityEngine;

public class Sarcofago : MonoBehaviour
{
    private Animation m_animation;
    [SerializeField] bool hasEnemy;
    private bool playerIn;
    private Inventarioimprovisado inventario;
    [SerializeField] InventoryObject inventory;
    [SerializeField] AudioClip openSound;
    public Collider itemCollider;
    bool hasActivated;


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
                if (inventory.Container[i].item.name == "Crowbar" && !hasActivated)
                {
                    
                    hasActivated = true;
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
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
        }
    }

    public void ActivateItemCollider()
    {
        if(itemCollider != null)
        {
            itemCollider.enabled = true;
        }
    }
}
