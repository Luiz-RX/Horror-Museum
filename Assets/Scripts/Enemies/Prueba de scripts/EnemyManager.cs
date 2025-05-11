using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [SerializeField] private List<EnemyAI> allEnemies = new List<EnemyAI>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterEnemy(EnemyAI enemy)
    {
        if (!allEnemies.Contains(enemy))
            allEnemies.Add(enemy);
    }

    public void NotifyRoomChange(string roomName, bool playerEntered)
    {
        foreach (var enemy in allEnemies)
        {
            if (enemy.roomName == roomName)
                enemy.SetPlayerInRoom(playerEntered);
        }
    }

    
}