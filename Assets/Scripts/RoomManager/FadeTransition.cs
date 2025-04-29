using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    public static FadeTransition Instance;

    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private float fadeDuration = 0.5f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartFade(System.Action onMidFade)
    {
        StartCoroutine(FadeRoutine(onMidFade));
    }

    private IEnumerator FadeRoutine(System.Action onMidFade)
    {
        // Fade out
        yield return StartCoroutine(Fade(0f, 0.7f));

        // Ejecutar lógica de cambio de sala
        onMidFade?.Invoke();

        // Fade in
        yield return StartCoroutine(Fade(0.7f, 0f));
    }

    private IEnumerator Fade(float from, float to)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(from, to, timer / fadeDuration);
            yield return null;
        }
        fadeCanvasGroup.alpha = to;
    }
}