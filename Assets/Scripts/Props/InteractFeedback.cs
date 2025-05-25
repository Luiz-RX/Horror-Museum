using UnityEngine;

public class InteractFeedback : MonoBehaviour
{
    [SerializeField] private GameObject uiInteract;

    private void OnTriggerEnter(Collider other)
    {
        uiInteract.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        uiInteract.SetActive(false);
    }
}
