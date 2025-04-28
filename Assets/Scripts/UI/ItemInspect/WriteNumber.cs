using UnityEngine;
using TMPro;
using NUnit.Framework.Constraints;

public class WriteNumber : MonoBehaviour
{
    public TextMeshProUGUI number;
    
    Keypad kp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kp = FindAnyObjectByType<Keypad>();
        
    }

    // Update is called once per frame
    void Update()
    {
        number.text = kp.answerToSend;
    }
}
