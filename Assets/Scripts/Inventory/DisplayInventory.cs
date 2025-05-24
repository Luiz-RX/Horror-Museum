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
    string currenttInventoryName;
    string previousInventoryName = "";
    bool hasUpdatedItem;
    int invPosition;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    void Start()
    {
        inventoryViewer = FindAnyObjectByType<Item3DViewerInventory>();
        invPosition = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
        currenttInventoryName = inventory.Container[invPosition].item.name;
        if(previousInventoryName != currenttInventoryName)
        {
            inventoryViewer.inspectItem(inventory.Container[invPosition].item.prefab);
            descriptionText.text = inventory.Container[invPosition].item.description;
            itemName.text = inventory.Container[invPosition].item.name;
            previousInventoryName = currenttInventoryName;
        }
        itemCount.text = "Count: " + inventory.Container[invPosition].amount;


        if (inventory.Container[invPosition].item.type == ItemType.Consumable)
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

    public void NextItem()
    {
        invPosition++;
        if (invPosition == inventory.Container.Count) invPosition = 0;
    }

    public void PreviousItem()
    {

        invPosition--;
        if (invPosition < 0) invPosition = inventory.Container.Count-1;
    }
}
