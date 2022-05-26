using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null) {
            Debug.LogError("Multiple managers on scene!");
        }
        instance = this;
     
    }

    public GameObject standartTurretPrefab;
    public GameObject shotgunTurretPrefab;
    public GameObject exposiveTurretPrefab;
    public GameObject fireTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild() {

        return turretToBuild;

    }

    public void SetTurretToBuild(GameObject turret) {

        turretToBuild = turret;

    }
}
