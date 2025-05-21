using UnityEngine;
[CreateAssetMenu(fileName = "New Ammo Object", menuName = "Inventory System/Items/Ammo")]

public class AmmoObject : ItemObject
{
    public int ammount;
    private void Awake()
    {
        type = ItemType.Ammo;
    }
}
