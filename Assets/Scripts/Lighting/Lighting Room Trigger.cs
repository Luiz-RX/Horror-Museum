using UnityEngine;

public class LightingRoomTrigger : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private string roomLayerName;
    [SerializeField] private GameObject[] lightsToEnable; // Luces de la sala

    [Header("Layers que siempre deben verse (Player, UI, etc)")]
    [SerializeField] private LayerMask persistentLayers;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // Estado inicial, solo mostrar Room 1 + capas persistentes
        int roomLayer = LayerMask.NameToLayer("Room 1");
        mainCamera.cullingMask = persistentLayers | (1 << roomLayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ha entrado en el collider");
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Activando capa: " + roomLayerName);
            int layer = LayerMask.NameToLayer(roomLayerName);
            mainCamera.cullingMask = persistentLayers | (1 << layer);

            foreach (GameObject lightObj in lightsToEnable)
            {
                if (lightObj != null)
                    lightObj.SetActive(true);
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject lightObj in lightsToEnable)
            {
                if (lightObj != null)
                    lightObj.SetActive(false);
            }
        }

        
    }
}
