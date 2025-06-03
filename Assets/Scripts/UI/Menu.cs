using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    bool isMenuActive;
    [SerializeField] GameObject vpFullHealth;
    [SerializeField] GameObject vpHalfHealth;
    [SerializeField] GameObject vpLowHealth;

    public OpenSettingsMenu openSettingsMenu;
    public Health health;

    Health plHealth;

    private void Start()
    {
        plHealth = FindAnyObjectByType<Health>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && health.isDead == false && !openSettingsMenu.isPaused)
        {
            if (!isMenuActive)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isMenuActive = true;
                menuPanel.SetActive(true);
                Time.timeScale = 0f;
            } else if (isMenuActive)
            {
                CloseMenu();
               
            }
        }

        if (plHealth.health >= 5)
        {
            vpFullHealth.SetActive(true);
            vpHalfHealth.SetActive(false);
            vpLowHealth.SetActive(false);
        }
        else if (plHealth.health < 5 && plHealth.health > 2)
        {
            vpFullHealth.SetActive(false);
            vpHalfHealth.SetActive(true);
            vpLowHealth.SetActive(false);
        }
        else if (plHealth.health < 3)
        {
            vpFullHealth.SetActive(false);
            vpHalfHealth.SetActive(false);
            vpLowHealth.SetActive(true);
        }

        
    }

    public void CloseMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isMenuActive = false;
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    
}
