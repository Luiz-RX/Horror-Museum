using UnityEngine;

public class MammothSound : MonoBehaviour
{

    [SerializeField] AudioClip soundClip;
    public Transform mammoth;

    private void OnTriggerEnter(Collider other)
    {
        SoundFXManager.Instance.PlaySoundFXClip(soundClip, mammoth, 3f);
        Destroy(gameObject);
    }
}
