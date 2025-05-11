using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private string roomName;
    private RoomManager roomManager;

    private void Start()
    {
        roomManager = FindAnyObjectByType<RoomManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("[RoomTrigger] Jugador entró en sala: " + roomName);
            FadeTransition.Instance.StartFade(() => {
                RoomManager.Instance.EnterRoom(roomName);
            });
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyManager.Instance.NotifyRoomChange(roomName, false);
        }
    }
}