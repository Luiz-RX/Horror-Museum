using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;


public class CameraCameraZoom : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject interactCam;
    public GameObject interactCam2;

    public TextMeshProUGUI textoSalaCamara;

    public GameObject camWatchUI;

    public GameObject[] uiButtons;

    public GameObject[] uiCams;

    public GameObject[] cameras;

    public CinemachineBrain mainCamBrain;

    public int securityCam;

    int activeCam = 1;
    int activeSecurityCam;

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
                activeSecurityCam = securityCam;
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

            textoSalaCamara.text = "Room: " + (currentCam+1);
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
                CloseCams();
                ChangeCam();
            }

            canInteract = false;
        }
    }

    public void ChangeCam()
    {
        mainCamBrain.DefaultBlend.Time = 2f;
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
            interactCam2.SetActive(false);
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
        mainCamBrain.DefaultBlend.Time = 0f;

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
        camWatchUI.SetActive(true);
        Debug.Log("Changed cam to cam " + camNum);
    }

    public void CloseCams()
    {

        isWatchingCams = false;
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
        if (activeSecurityCam == 1)
        {

        interactCam.SetActive(true);
        } else
        {
            interactCam2.SetActive(true);
        }
        DefaultCam();
        ActivateCamUI();
        camWatchUI.SetActive(false);
        uiButtons[0].SetActive(true);
    }

    public void NextCam()
    {
        currentCam++;
        if (currentCam == cameras.Length)
        {
            currentCam = 0;
        } 
        ChangeCamFullscreen(currentCam);
    }

    public void PrevCam()
    {
        currentCam -= 1;
        
        if (currentCam < 0)
        {
            currentCam = 3;
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
