using UnityEngine;

public class ActivateBoss : MonoBehaviour
{
    [SerializeField] private CavernicolaMiniBoss cavern;

    private void OnTriggerEnter(Collider other)
    {
        cavern.ActivateBoss();
        cavern.SetPlayerInRoom(true);
    }
}
