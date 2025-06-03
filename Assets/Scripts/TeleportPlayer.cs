using System.Collections;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject teleportPosition;
    public GameObject player;
    public Animator fadePanel;
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

    

    public void Teleport()
    {
        
        player.transform.position = tpPos;

        
    }

    public void DisableMovement()
    {
        characterController.enabled = false;

    }

    public void EnableMovement()
    {
        characterController.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            fadePanel.SetTrigger("Play");
            StartCoroutine(TeleportSequence());
            //other.gameObject.transform.position += tpPos;
        }
    }

    IEnumerator TeleportSequence()
    {
        DisableMovement();
        yield return new WaitForSeconds(0.75f);
        Teleport();
        yield return new WaitForSeconds(0.75f);
        EnableMovement();
    }
}
