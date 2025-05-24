using UnityEngine;


public class ItemInteract : MonoBehaviour
{
    bool canInteract;
    Item3DViewer itemViewer;
    public GameObject item;

    void Start()
    {
        itemViewer = FindAnyObjectByType<Item3DViewer>();
    }


    void Update()
    {

        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //InteractItem
                if (itemViewer.itemSelected == false)
                {
                    itemViewer.inspectItem(item);
                }
                else
                {
                    itemViewer.stopInspectingItem();
                }

            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Can Interact");
            canInteract = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Can Not Interact");
            canInteract = false;
            itemViewer.stopInspectingItem();
        }
    }
}
