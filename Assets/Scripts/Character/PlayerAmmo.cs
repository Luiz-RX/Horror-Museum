using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public int ammo = 12;      
    public int extraAmmo;

    public InventoryObject inventory;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    Reload();
        //}

        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (inventory.Container[i].item.name == "9x19mm Ammo")
            {
                extraAmmo = inventory.Container[i].amount;
            }
        }
    }

    public void TakeAmmo()
    {
        if (ammo > 0)
            ammo -= 1;
    }

    public void Reload()
    {
        int neededAmmo = 12 - ammo;           

        if (neededAmmo > 0 && extraAmmo > 0)
        {
            int ammoToLoad = Mathf.Min(neededAmmo, extraAmmo); 
            ammo += ammoToLoad;
            //extraAmmo -= ammoToLoad;
            for (int i = 0; i < inventory.Container.Count; i++)
            {
                if (inventory.Container[i].item.name == "9x19mm Ammo")
                {
                    inventory.Container[i].amount -= ammoToLoad;
                }
            }

        }
        else
        {
           //Se puede poner el sonidito ese to guapo de click
        }
    }

    public void GiveAmmo(int ammoToGive)
    {
        //extraAmmo += ammoToGive;
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (inventory.Container[i].item.name == "9x19mm Ammo")
            {
                inventory.Container[i].amount += ammoToGive;
            }
        }
    }
}
