using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    Item3DViewerInventory inventoryViewer;
    public int inventoryIndex = 0;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI itemName;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    void Start()
    {
        inventoryViewer = FindAnyObjectByType<Item3DViewerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        inventoryViewer.inspectItem(inventory.Container[0].item.prefab);
        descriptionText.text = inventory.Container[0].item.description;
        itemName.text = inventory.Container[0].item.name;
    }

    public void CreateDisplay()
    {

    }
}
