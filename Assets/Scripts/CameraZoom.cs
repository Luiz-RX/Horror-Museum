using UnityEngine;
using Unity.Cinemachine;


public class CameraZoom : MonoBehaviour
{
    public CinemachineCamera playerCam;
    public CinemachineCamera interactCam;

    public Collider[] buttonColliders;

    int activeCam = 1;

    bool canInteract;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Change cam and enable buttons
                ChangeCam();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }

    void ChangeCam() 
    { 
        if (activeCam == 1)
        {
            playerCam.enabled = false;
            interactCam.enabled = true;
            EnableButtons();
            activeCam = 2;

        } else if(activeCam == 2)
        {
            interactCam.enabled = false;
            playerCam.enabled = true;
            DisableButtons();
            activeCam = 1;
        }
    }

    void EnableButtons()
    {
        for (int i = 0; i < buttonColliders.Length; i++)
        {
            buttonColliders[i].enabled = true;
        }
    }

    void DisableButtons()
    {
        for (int i = 0; i < buttonColliders.Length; i++)
        {
            buttonColliders[i].enabled = false;
        }
    }
}
