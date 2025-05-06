using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;

    [SerializeField] AudioSource soundFXObject;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //SPAWNEAR AUDIO SOURCE
        AudioSource audiSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        //ASIGNAR CLIP DE AUDIO
        audiSource.clip = audioClip;
        //ASIGNAR VOLUMEN
        audiSource.volume = volume;
        //EJECUTAR SONIDO
        audiSource.Play();
        //OBTENER DURACION DE CLIP DE AUDIO
        float clipLength = audiSource.clip.length;
        //DESTRUIR AUDIO SOURCE
        Destroy(audiSource.gameObject, clipLength);
    }

    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        //ASIGNAR SONIDO DE ARRAY
        int rand = Random.Range(0, audioClip.Length);
        //SPAWNEAR AUDIO SOURCE
        AudioSource audiSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        //ASIGNAR CLIP DE AUDIO
        audiSource.clip = audioClip[rand];
        //ASIGNAR VOLUMEN
        audiSource.volume = volume;
        //EJECUTAR SONIDO
        audiSource.Play();
        //OBTENER DURACION DE CLIP DE AUDIO
        float clipLength = audiSource.clip.length;
        //DESTRUIR AUDIO SOURCE
        Destroy(audiSource.gameObject, clipLength);
    }
}
