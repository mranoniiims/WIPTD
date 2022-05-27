using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable3D : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Color normalColor;
    public Color hoverColor;
    public Vector3 positionOffset;
    public Color notEnoughMoneyColor;


    [Header("Optional")]
    public GameObject turret;

    private Renderer ren;

    BuildManager buildManager;

    void Start()
    {
        ren = GetComponent<Renderer>();
        normalColor = ren.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!buildManager.CanBuild)
            return;
            

        if (buildManager.HasMoney)
        {
            ren.material.color = hoverColor;
        }
        else
        {
            ren.material.color = notEnoughMoneyColor;
        } 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
 
        ren.material.color = normalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (!buildManager.CanBuild) {
            return;
        }

        if (turret != null) {
            Debug.Log("Can't build there!");
            return;
        }

        buildManager.BuildTurretOn(this);

    }
}
