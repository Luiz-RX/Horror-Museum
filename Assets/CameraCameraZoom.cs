using System.Collections;
using UnityEngine;

public class CameraCameraZoom : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject interactCam;

    public GameObject camWatchUI;

    public GameObject[] uiButtons;

    public GameObject[] uiCams;

    public GameObject[] cameras;

    int activeCam = 1;

    bool isWatchingCams;
    bool canInteract;
    int currentCam;

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
                SetCursorLock();
                ChangeCam();
            }
        }

        if(isWatchingCams)
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                if (cameras[i].activeInHierarchy)
                {
                    currentCam = i;
                }
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
            StartCoroutine(ActivateCamUI());
            DefaultCam();
            activeCam = 2;

        }
        else if (activeCam == 2 && !isWatchingCams)
        {
            playerCam.SetActive(true);
            interactCam.SetActive(false);
            for (int i =0; i < uiButtons.Length; i++) 
            {
                uiButtons[i].SetActive(false);
            }
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
            }
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

    public void ChangeCamFullscreen(int camNum)
    {

        isWatchingCams = true;
        interactCam.SetActive(false);
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == camNum)
            {
                cameras[i].SetActive(true);
            } else
            {
                cameras[i].SetActive(false);
            }
        }
        for (int i = 0; i < uiButtons.Length; i++)
        {
            uiButtons[i].SetActive(false);
        }
        StartCoroutine(ActivateCamUI2());
        Debug.Log("Changed cam to cam " + camNum);
    }

    public void CloseCams()
    {
        isWatchingCams = false;
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
        interactCam.SetActive(true);
        DefaultCam();
        ActivateCamUI();
        camWatchUI.SetActive(true);
    }

    public void NextCam()
    {
        currentCam++;
        if (currentCam > cameras.Length)
        {
            currentCam = 0;
        } else if (currentCam < 0)
        {
            currentCam = cameras.Length;
        }
        ChangeCamFullscreen(currentCam);
    }

    public void PrevCam()
    {
        currentCam--;
        if (currentCam > cameras.Length)
        {
            currentCam = 0;
        }
        else if (currentCam < 0)
        {
            currentCam = cameras.Length;
        }
        ChangeCamFullscreen(currentCam);
    }

    IEnumerator ActivateCamUI()
    {
        yield return new WaitForSeconds(2f);
        uiButtons[0].SetActive(true);
    }

    IEnumerator ActivateCamUI2()
    {
        yield return new WaitForSeconds(2f);
        camWatchUI.SetActive(true);
    }

    public void DefaultCam()
    {
        for (int i = 0;i < uiCams.Length;i++) 
        { 
            if (i == 0)
            {
                uiCams[i].SetActive(true);
            } else
            {
                uiCams[i].SetActive(false);
            }
        }
    }

    

}
