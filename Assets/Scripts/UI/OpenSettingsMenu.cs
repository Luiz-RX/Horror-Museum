using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenSettingsMenu : MonoBehaviour
{
    SettingsMenu settings;
    public GameObject pauseMenuUI;


    public bool isPaused;
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
            if (!isPaused)
            {
               PauseGame();
                
            } else
            {
               UnpauseGame();
            }
        }

        if (!settings.settingsUI.activeInHierarchy && isPaused && !pauseMenuUI.activeInHierarchy)
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
        isPaused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        settings.settingsUI.SetActive(false);
        isPaused = false;
    }

    public void GoBackToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
