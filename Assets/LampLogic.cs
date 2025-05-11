using System.Collections;
using UnityEditor.Analytics;
using UnityEngine;

public class LampLogic : MonoBehaviour
{
    public bool returnToNormal;
    [HideInInspector] public Animator anim;
    InteractLever lever;
    [SerializeField] AudioClip returnSound;
    CavernicolaMiniBoss miniboss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        returnToNormal = true;
        anim = GetComponent<Animator>();
        lever = FindAnyObjectByType<InteractLever>();
        miniboss = FindAnyObjectByType<CavernicolaMiniBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Return()
    {
        yield return new WaitForSeconds(2f);
        if (returnToNormal)
        {
            anim.SetTrigger("Return");
            PlayReturnSound();
        }
    }

    void ResetLever()
    {
        lever.ReturnLever();
    }

    void PlayReturnSound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(returnSound, this.transform, 1f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MiniBoss")
        {
            miniboss.TryKillFromLamp();
            Debug.Log("Boss Hit");
        }
    }
}
