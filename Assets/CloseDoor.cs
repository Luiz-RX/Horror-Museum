using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    bool hasClosed;
    public Animator Door;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!hasClosed)
            {
                hasClosed = true;
                Door.SetTrigger("DoorClose");
            }
        }
    }
}
