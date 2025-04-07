using UnityEngine;
using TMPro;


public class Keypad : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enteredNumbers;
    private string answer = "1234";
    void Start()
    {
        
    }

    public void setNum(int num)
    {
        if (enteredNumbers.textInfo.characterCount < 4)
        {
            enteredNumbers.text += num.ToString();
        }
    }

    public void Execute()
    {
        if (enteredNumbers.text == answer)
        {
            //Abrir Puerta
            Debug.Log("SI");
        } else
        {
            Debug.Log("Error");
        }
    }

    public void Clear()
    {
        enteredNumbers.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
