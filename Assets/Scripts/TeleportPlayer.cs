using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject teleportPosition;
    public GameObject player;
    public GameObject fadePanel;
    PlayerMovement playerMovement;
    new Vector3 tpPos;
    CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        tpPos = teleportPosition.transform.position;
    }

    

    void Teleport()
    {
        characterController.enabled = false;
        player.transform.position = tpPos;
        characterController.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Luis es un guarro");
            Teleport();
            //other.gameObject.transform.position += tpPos;
        }
    }
}
