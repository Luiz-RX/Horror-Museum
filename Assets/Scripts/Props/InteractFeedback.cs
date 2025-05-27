using UnityEngine;

public class InteractFeedback : MonoBehaviour
{
    [SerializeField] private GameObject uiInteract;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            uiInteract.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiInteract.SetActive(false);
        }
       
    }
}
