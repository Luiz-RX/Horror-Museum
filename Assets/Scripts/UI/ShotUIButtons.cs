using UnityEngine;

public class ShotUIButtons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject restartButton;
    public GameObject backButton;
    public GameObject demoText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowButtons()
    {
        if(demoText != null) demoText.SetActive(true);
        if (restartButton != null) restartButton.SetActive(true);
        backButton.SetActive(true); 
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
