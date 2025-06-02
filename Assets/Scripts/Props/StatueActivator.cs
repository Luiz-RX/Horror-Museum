using UnityEngine;

public class StatueActivator : MonoBehaviour
{
    bool canInteract;
    public RotateStatue rtStatue;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(canInteract && Input.GetKeyDown(KeyCode.E))
        {
            rtStatue.Rotate();
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
