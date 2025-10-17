using Unity.Cinemachine;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineCamera cinemachineCamera;
    private CinemachineBasicMultiChannelPerlin noise;
    private float shakeTimer;
    private float startIntensity;
    private float shakeDuration;

    private void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
        noise = cinemachineCamera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        if (noise == null) return;

        startIntensity = intensity;
        shakeDuration = time;
        shakeTimer = time;

        noise.AmplitudeGain = intensity;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            float t = 1 - (shakeTimer / shakeDuration);
            noise.AmplitudeGain = Mathf.Lerp(startIntensity, 0f, t);

            if (shakeTimer <= 0f)
            {
                noise.AmplitudeGain = 0f;
            }
        }
    }
}