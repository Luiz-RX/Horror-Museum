using System.Collections;
using UnityEngine;

public class CameraCameraZoom : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject interactCam;
    public GameObject[] KeycodeUI;

    public Collider[] buttonColliders;

    int activeCam = 1;

    bool canInteract;

    void Start()
    {

    }


    void Update()
    {
        if (canInteract)
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
        if (other.tag == "Player")
        {
            canInteract = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (activeCam == 2)
            {
                ChangeCam();
            }

            canInteract = false;
        }
    }

    public void ChangeCam()
    {
        if (activeCam == 1)
        {
            playerCam.SetActive(false);
            interactCam.SetActive(true);
            //for (int i = 0; i < KeycodeUI.Length; i++)
            //{
            //    KeycodeUI[i].SetActive(true);
            //}
            
            activeCam = 2;

        }
        else if (activeCam == 2)
        {
            playerCam.SetActive(true);
            interactCam.SetActive(false);
            //for (int i = 0; i < KeycodeUI.Length; i++)
            //{
            //    KeycodeUI[i].SetActive(false);
            //}
           
            activeCam = 1;
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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
