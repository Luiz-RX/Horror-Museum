using UnityEngine;

public class Folleto : MonoBehaviour
{
    [SerializeField] private GameObject colliderMamut;
    [SerializeField] private GameObject uiFeedback;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            colliderMamut.SetActive(true);
            uiFeedback.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            
            uiFeedback.SetActive(false);
        }
        
    }
}
