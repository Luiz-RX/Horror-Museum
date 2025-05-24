using UnityEngine;

public class Esfinge : MonoBehaviour
{
    Animation animation;
    bool canInteract;
    [SerializeField] InventoryObject inventory;
    private void Start()
    {
        animation = GetComponentInParent<Animation>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            for (int i = 0; i < inventory.Container.Count; i++)
            {
                if (inventory.Container[i].item.name == "SphinxFinger")
                {
                    if (animation != null) animation.Play();
                    else Debug.Log("no hay animacion de esfinge");
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
