using UnityEngine;

public class MammothDeathSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool canInteract;
    [SerializeField] AudioClip mdSound;
    public Transform mammoth;
    bool hasPlayedSound;
    void Update()
    {

        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!hasPlayedSound )
                {
                    hasPlayedSound = true;
                    SoundFXManager.Instance.PlaySoundFXClip(mdSound, mammoth, 1f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            canInteract = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            
            canInteract = false;
            
        }
    }
}
