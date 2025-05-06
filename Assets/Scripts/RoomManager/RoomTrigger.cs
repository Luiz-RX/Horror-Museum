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
            FadeTransition.Instance.StartFade(() => {
                RoomManager.Instance.EnterRoom(roomName);
            });
            EnemyManager.Instance.NotifyRoomChange(roomName, true);
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