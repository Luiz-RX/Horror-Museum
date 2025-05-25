using UnityEngine;

public class DoorEgipt : MonoBehaviour
{
    [SerializeField] private Animation animation;
    
    public InventoryObject inventory;
    [SerializeField]private bool hasKeys;
    private bool canInteract;

    private void Update()
    {
        if(canInteract)
        {
            Interact();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            canInteract= false;
        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < inventory.Container.Count; i++)
            {
                if (inventory.Container[i].item.name == "Keys")
                {
                    animation.Play();
                    this.gameObject.SetActive(false);
                }
                
            }
            

        }

    }
}
