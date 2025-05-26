using UnityEngine;


public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsUI;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateUI()
    {
        settingsUI.SetActive(true);
    }


}
