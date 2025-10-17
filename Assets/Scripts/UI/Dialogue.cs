using UnityEngine;
using TMPro;
using System.Collections;
using UnityEditor;

public class Dialogue : MonoBehaviour
{
   public TextMeshProUGUI textMeshProUGUI;
    public string[] lines;
    public float textSpeed = 0.05f;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip voiceClip;   // pequeño clip tipo "blip"
    public float pitchMin = 0.9f;
    public float pitchMax = 1.3f;
    public float volume = 0.4f;

    private int index;

    void Start()
    {
        textMeshProUGUI.text = string.Empty;
        StartDialogue();
    }

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

            // 🔊 Sonido tipo Animal Crossing
            if (char.IsLetterOrDigit(c)) // evita que suene con espacios o signos
            {
                audioSource.pitch = Random.Range(pitchMin, pitchMax);
                audioSource.PlayOneShot(voiceClip, volume);
            }

            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textMeshProUGUI.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
