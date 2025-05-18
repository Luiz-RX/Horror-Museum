using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public int ammo = 12;      
    public int chamber = 24;   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
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

        if (neededAmmo > 0 && chamber > 0)
        {
            int ammoToLoad = Mathf.Min(neededAmmo, chamber); 
            ammo += ammoToLoad;
            chamber -= ammoToLoad;

            
        }
        else
        {
           //Se puede poner el sonidito ese to guapo de click
        }
    }

    public void GiveAmmo(int ammoToGive)
    {
        chamber += ammoToGive;
    }
}
