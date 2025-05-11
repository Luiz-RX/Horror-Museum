using UnityEngine;

public class InteractLever : MonoBehaviour
{
    private bool canInteract;
    [SerializeField] int cooldown;
    bool canPullLever;
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    

    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PullLever();
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
    }
}
