using UnityEngine;

public class GameStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject cameraMainMenu;
    public GameObject startText;
    void Start()
    {
        cameraMainMenu.SetActive(false);
        startText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            startText.SetActive(false);
            cameraMainMenu.SetActive(true);
        }
    }
}
