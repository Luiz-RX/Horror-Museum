using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    Item3DViewerInventory inventoryViewer;
    public int inventoryIndex = 0;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI itemName;
    public GameObject button;
    public TextMeshProUGUI itemCount;

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
        itemCount.text = "Count: " + inventory.Container[0].amount;


        if (inventory.Container[0].item.type == ItemType.Consumable)
        {
            //Activar botón de usar
            button.SetActive(true);
        } else
        {
            button.SetActive(false);
        }
    }

    public void CreateDisplay()
    {

    }
}
