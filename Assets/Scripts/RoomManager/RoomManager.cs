using UnityEngine;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    [System.Serializable]
    public class Room
    {
        public string name;
        public GameObject rootObject;
        public GameObject[] lights;
        public string layerName;
    }

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask persistentLayers;
    [SerializeField] private List<Room> rooms = new List<Room>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (mainCamera == null)
            mainCamera = Camera.main;

        // Al iniciar desactiva todo excepto la primera sala
        EnterRoom(rooms[0].name);
    }

    public void EnterRoom(string roomName)
    {
        foreach (Room room in rooms)
        {
            bool isActive = room.name == roomName;

            // Activar/desactivar root GameObject
            if (room.rootObject != null)
                room.rootObject.SetActive(isActive);

            // Activar/desactivar luces
            foreach (GameObject light in room.lights)
            {
                if (light != null)
                    light.SetActive(isActive);
            }

            // Cambiar la culling mask solo si es la sala activa
            if (isActive)
            {
                int roomLayer = LayerMask.NameToLayer(room.layerName);
                mainCamera.cullingMask = persistentLayers | (1 << roomLayer);
            }
        }
    }
}
