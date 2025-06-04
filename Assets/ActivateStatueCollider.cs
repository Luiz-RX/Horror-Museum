using UnityEngine;

public class ActivateStatueCollider : MonoBehaviour
{

    bool canInteract;
    public GameObject statueCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                statueCollider.SetActive(true);

            }
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
            
            canInteract = false;
            
        }
    }
}
