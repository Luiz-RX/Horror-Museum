using System.Collections;
using UnityEngine;

public class InteractLever : MonoBehaviour
{
    private bool canInteract;
    [SerializeField] int cooldown;
    bool canPullLever;
    Animator anim;
    [SerializeField] AudioClip leverSound;

    LampLogic lampLogic;
    
    void Start()
    {
        canPullLever = true;
        anim = GetComponent<Animator>();
        lampLogic = FindAnyObjectByType<LampLogic>();
    }

    // Update is called once per frame
    

    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E) && canPullLever)
            {
                canPullLever = false;
                PullLever();
                StartCoroutine(LeverCooldown());
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

    private void PullLever()
    {
        anim.SetTrigger("Pull");
        lampLogic.anim.SetTrigger("Fall"); 
    }

    public void ReturnLever()
    {
        anim.SetTrigger("Return");
    }

    IEnumerator LeverCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canPullLever = true;
    }

    void PlayLeverSound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(leverSound, this.transform, 1f);
    }
}
