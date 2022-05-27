using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{

    public TurretBlueprint canonTurrent;
    public TurretBlueprint shotgunTurret;
    public TurretBlueprint explosiveTurret;
    public TurretBlueprint fireTurret;

    [Header("Shop prices setup")]
    public TMPro.TMP_Text displayPlayerMoney;
    public TMPro.TMP_Text turret1price;
    public TMPro.TMP_Text turret2price;
    public TMPro.TMP_Text turret3price;
    public TMPro.TMP_Text turret4price;

    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void Update()
    {
        displayPlayerMoney.text = Mathf.Round(PlayerStats.Money).ToString() + "c";
    }

    public static Shop instance;

    void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Multiple shop instances on scene!");
            }
            instance = this;

        turret1price.text = Mathf.Round(canonTurrent.cost).ToString() + "c";
        turret2price.text = Mathf.Round(shotgunTurret.cost).ToString() + "c";
        turret3price.text = Mathf.Round(explosiveTurret.cost).ToString() + "c";
        turret4price.text = Mathf.Round(fireTurret.cost).ToString() + "c";

        }

    public void SelectCannonTurret() {
    Debug.Log("Cannon Turret Selected!");
        buildManager.SelectTurretToBuild(canonTurrent);
    
    }

    public void SelectShotgunTurret()
    {
        Debug.Log("Shotgun Turret Selected!");
        buildManager.SelectTurretToBuild(shotgunTurret);
    }

    public void SelectExplosiveTurret()
    {
        Debug.Log("Explosive Turret Selected!");
        buildManager.SelectTurretToBuild(explosiveTurret);

    }

    public void SelectFireTurret()
    {
        Debug.Log("Fire Turret Selected!");
        buildManager.SelectTurretToBuild(fireTurret);
    }

    
}
