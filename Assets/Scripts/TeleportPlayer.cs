using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportPosition;
    public GameObject player;
    public GameObject fadePanel;
    PlayerMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    

    void Teleport()
    {

    }
}
