using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenSettingsMenu : MonoBehaviour
{
    SettingsMenu settings;
    public GameObject pauseMenuUI;


    public bool isMenuOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settings = FindAnyObjectByType<SettingsMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isMenuOpen)
            {
               PauseGame();
                
            } else
            {
               UnpauseGame();
            }
        }

        if (!settings.settingsUI.activeInHierarchy && isMenuOpen && !pauseMenuUI.activeInHierarchy)
        {
            pauseMenuUI.SetActive(true);
        }
    }



    public void EnableSettingsUI()
    {
        settings.settingsUI.SetActive(true);
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        isMenuOpen = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        settings.settingsUI.SetActive(false);
        isMenuOpen = false;
    }

    public void GoBackToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
