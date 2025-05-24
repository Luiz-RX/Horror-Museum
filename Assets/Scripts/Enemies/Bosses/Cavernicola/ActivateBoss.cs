using UnityEngine;

public class ActivateBoss : MonoBehaviour
{
    [SerializeField] private CavernicolaMiniBoss cavern;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cavern.ActivateBoss();
            cavern.SetPlayerInRoom(true);
        }
       
    }
}
