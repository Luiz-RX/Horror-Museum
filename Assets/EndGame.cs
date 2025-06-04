using UnityEngine;

public class EndGame : MonoBehaviour
{
    bool canInteract;
    public GameObject endPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            endPanel.SetActive(true);
            //if (animation != null) animation.Play();
            //else Debug.Log("no hay animacion de esfinge");
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
