using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI textMeshProUGUI;
    public RectTransform dialoguePanel; // ← el panel que vibra

    [Header("Dialogue Settings")]
    public string[] lines;
    public float textSpeed = 0.05f;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip voiceClip;
    public float pitchMin = 0.9f;
    public float pitchMax = 1.3f;
    public float volume = 0.4f;

    [Header("Shake Settings")]
    public float shakeIntensity = 3f;  // cuánto se mueve el panel
    public float shakeDuration = 0.05f; // duración del pequeño temblor

    private int index;
    private Vector3 originalPos;

    void Start()
    {
        textMeshProUGUI.text = string.Empty;
        textMeshProUGUI.enableWordWrapping = true;
        textMeshProUGUI.overflowMode = TextOverflowModes.Overflow;

        if (dialoguePanel != null)
            originalPos = dialoguePanel.localPosition;

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

            if (char.IsLetterOrDigit(c))
            {
                // Sonido blip tipo Animal Crossing
                audioSource.pitch = Random.Range(pitchMin, pitchMax);
                audioSource.PlayOneShot(voiceClip, volume);

                // Pequeña sacudida visual
                if (dialoguePanel != null)
                    StartCoroutine(ShakePanel());
            }

            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator ShakePanel()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-shakeIntensity, shakeIntensity),
            Random.Range(-shakeIntensity, shakeIntensity),
            0
        );

        dialoguePanel.localPosition = originalPos + randomOffset;

        yield return new WaitForSeconds(shakeDuration);

        dialoguePanel.localPosition = originalPos;
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
