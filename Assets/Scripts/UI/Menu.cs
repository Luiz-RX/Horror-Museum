using UnityEngine;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    bool isMenuActive;
    [SerializeField] GameObject vpFullHealth;
    [SerializeField] GameObject vpHalfHealth;
    [SerializeField] GameObject vpLowHealth;

    Health plHealth;

    private void Start()
    {
        plHealth = FindAnyObjectByType<Health>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isMenuActive)
            {
                isMenuActive = true;
                menuPanel.SetActive(true);
            } else if (isMenuActive)
            {
                isMenuActive = false;
                menuPanel.SetActive(false);
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
}
