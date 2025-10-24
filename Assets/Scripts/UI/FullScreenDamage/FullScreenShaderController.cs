using UnityEngine;

public class FullScreenShaderController : MonoBehaviour
{
    private Health health;

    [Header("Post-Process Damage Effect")]
    [SerializeField] private Material damageVignette;

    [Header("Configuración de intensidades por fase")]
    [SerializeField] private float highHealthPower = 10f;   // 5–6 HP
    [SerializeField] private float midHealthPower = 3.2f;   // 3–4 HP
    [SerializeField] private float lowHealthPower = 1.6f;   // 0–2 HP

    [SerializeField] private float smoothSpeed = 5f; // velocidad de transición

    private float currentPower;
    private float targetPower;

    private void Start()
    {
        health = FindAnyObjectByType<Health>();

        if (damageVignette == null)
        {
            Debug.LogError("No se ha asignado el material de la viñeta.");
            enabled = false;
            return;
        }

        
        currentPower = highHealthPower;
        damageVignette.SetFloat("_VignettPower", currentPower);
    }

    private void Update()
    {
        if (health == null || damageVignette == null)
            return;

        UpdateTargetPower();
        SmoothTransition();
    }

  
    private void UpdateTargetPower()
    {
        if (health.health >= 5)
        {
            targetPower = highHealthPower; 
        }
        else if (health.health >= 3)
        {
            targetPower = midHealthPower; 
        }
        else
        {
            targetPower = lowHealthPower; 
        }
    }

    
    private void SmoothTransition()
    {
        currentPower = Mathf.Lerp(currentPower, targetPower, Time.deltaTime * smoothSpeed);
        damageVignette.SetFloat("_VignettPower", currentPower);
    }
}