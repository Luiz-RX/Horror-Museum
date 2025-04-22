using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item3DViewer : MonoBehaviour, IDragHandler
{

    public bool itemSelected;
    Vector3 inspectPos = new Vector3(100, 100, 100);
    private GameObject itemPrefab;
    [SerializeField] GameObject itemInspectUI;
    public CinemachineOrbitalFollow cameraRotation;
    
    void Start()
    {
        //cameraRotation = FindAnyObjectByType<CinemachineOrbitalFollow>();
    }

    
    void Update()
    {
        
    }

    public void inspectItem(GameObject item)
    {
        itemSelected = true;
        cameraRotation.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        itemInspectUI.SetActive(true);
        if (itemPrefab != null)
        {
            Destroy(itemPrefab.gameObject);
        }
        itemPrefab = Instantiate(item, inspectPos, Quaternion.identity);
    }

    public void stopInspectingItem()
    {
        itemSelected=false;
        cameraRotation.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        itemInspectUI.SetActive(false);
        if (itemPrefab != null)
        {
            Destroy(itemPrefab.gameObject);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        Quaternion itemRotation = Quaternion.Euler(eventData.delta.y, -eventData.delta.x, 0);
        itemPrefab.transform.rotation = itemRotation * itemPrefab.transform.rotation;
        //itemPrefab.transform.eulerAngles += new Vector3(-eventData.delta.y/2, -eventData.delta.x/2);
    }
}
