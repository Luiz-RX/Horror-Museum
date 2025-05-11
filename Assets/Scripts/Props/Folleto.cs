using UnityEngine;

public class Folleto : MonoBehaviour
{
    [SerializeField] private GameObject colliderMamut;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            colliderMamut.SetActive(true);
        }
    }
}
