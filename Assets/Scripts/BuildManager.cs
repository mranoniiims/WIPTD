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

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Interactable3D spot) {

        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, spot.GetBuildPosition(), Quaternion.identity);
        spot.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, spot.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left - " + PlayerStats.Money);
    }
    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;
    }
}
