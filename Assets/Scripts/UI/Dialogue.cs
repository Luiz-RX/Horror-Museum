using UnityEngine;
using TMPro;
using System.Collections;
using UnityEditor;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public string[] lines;
    public float textSpeeed;

    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshProUGUI.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textMeshProUGUI.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textMeshProUGUI.text = lines[index];
            }
        }

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textMeshProUGUI.text += c;
            yield return new WaitForSeconds(textSpeeed);

        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textMeshProUGUI.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
     }
}
