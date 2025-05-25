using UnityEngine;

public class DoorEgipt : MonoBehaviour
{
    [SerializeField] private Animation animation;
    public InventoryObject inventory;
    [SerializeField]private bool hasKeys;
    private bool onColl;

    private void Update()
    {
        Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Player"))
        {
            onColl = true;
            

        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //for (int i = 0; i < inventory.Container.Count; i++)
            //{
            //    if (inventory.Container[i].item.name == "Keys")
            //    {
            //        hasKeys = true;
            //    }
            //    else hasKeys = false;
            //}
            //if (hasKeys) 
            animation.Play();

        }

    }
}
