using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item3DViewerInventory: MonoBehaviour, IDragHandler
{

    public bool itemSelected;
    Vector3 inspectPos = new Vector3(100, 100, 100);
    private GameObject itemPrefab;
    
    //public CinemachineOrbitalFollow cameraRotation;
    
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
        
        
       
        if (itemPrefab != null)
        {
            Destroy(itemPrefab.gameObject);
        }
        itemPrefab = Instantiate(item, inspectPos, Quaternion.identity);
    }

    public void stopInspectingItem()
    {
        itemSelected=false;
        //cameraRotation.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        if (itemPrefab != null)
        {
            Destroy(itemPrefab.gameObject);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        Quaternion itemRotation = Quaternion.Euler(eventData.delta.y / 6, -eventData.delta.x / 6, 0);
        itemPrefab.transform.rotation = itemRotation * itemPrefab.transform.rotation;
        
        //itemPrefab.transform.eulerAngles += new Vector3(-eventData.delta.y/2, -eventData.delta.x/2);
    }
}
