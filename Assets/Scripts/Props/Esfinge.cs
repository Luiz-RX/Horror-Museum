using UnityEngine;

public class Esfinge : MonoBehaviour
{
    [SerializeField] AudioClip slideSound;
    Animator animator;
    bool hasPlayed;
    public Transform soundPos;
    bool canInteract;
    [SerializeField] InventoryObject inventory;
    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            for (int i = 0; i < inventory.Container.Count; i++)
            {
                if (inventory.Container[i].item.name == "Sphinx Finger")
                {
                    if(!hasPlayed)
                    {
                        animator.SetTrigger("Move");
                        SoundFXManager.Instance.PlaySoundFXClip(slideSound, soundPos, 1f);
                        hasPlayed = true;
                    }
                    
                }
            }
            //if (animation != null) animation.Play();
            //else Debug.Log("no hay animacion de esfinge");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if(other.GetComponent<Inventarioimprovisado>().pataEsfinge == true && Input.GetKeyDown(KeyCode.E))
            //{
            //    if (animation != null) animation.Play();
            //    else Debug.Log("no hay animacion de esfinge");

            //}
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
