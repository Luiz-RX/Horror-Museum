using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject interactCam;
    public GameObject KeycodeUI;

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
            playerCam.SetActive(false);
            interactCam.SetActive(true);
            StartCoroutine(ActivateUI());
            SetCursorLock();
            EnableButtons();
            activeCam = 2;

        } else if(activeCam == 2)
        {
            playerCam.SetActive(true);
            interactCam.SetActive(false);
            KeycodeUI.SetActive(false);
            SetCursorLock();
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

    IEnumerator ActivateUI()
    {
        yield return new WaitForSeconds(1.5f);
        if (activeCam == 2)
        {
            KeycodeUI.SetActive(true);
        }
    }

    void SetCursorLock()
    {
        if (activeCam == 1)
        {
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
        }
        else if (activeCam == 2)
        {
           Cursor.lockState= CursorLockMode.Locked;
           Cursor.visible = false;
        }
    }
}
