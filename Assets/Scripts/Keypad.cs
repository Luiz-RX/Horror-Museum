using UnityEngine;
using TMPro;


public class Keypad : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enteredNumbers;
    private string answer;
    public static int codeNum1;
    public static int codeNum2;
    public static int codeNum3;
    public static int codeNum4;
    void Start()
    {
        codeNum1 = Random.Range(0, 10);
        codeNum2 = Random.Range(0, 10);
        codeNum3 = Random.Range(0, 10);
        codeNum4 = Random.Range(0, 10);
        answer = "" +codeNum1 + codeNum2 +codeNum3 +codeNum4;
        Debug.Log(answer);
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
