using UnityEngine;


public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }


    public static Shop instance;

    void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Multiple shop instances on scene!");
            }
            instance = this;

        }

    public void PurchaseCannonTurret() {
    Debug.Log("Cannon Turret Selected!");
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    
    }

    public void PurchaseShotgunTurret()
    {
        Debug.Log("Shotgun Turret Selected!");
        buildManager.SetTurretToBuild(buildManager.shotgunTurretPrefab);
    }

    public void PurchaseExplosiveTurret()
    {
        Debug.Log("Explosive Turret Selected!");
        buildManager.SetTurretToBuild(buildManager.exposiveTurretPrefab);

    }

    public void PurchaseFireTurret()
    {
        Debug.Log("Fire Turret Selected!");
        buildManager.SetTurretToBuild(buildManager.fireTurretPrefab);
    }

    
}
