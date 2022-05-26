using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable3D : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Color normalColor;
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer ren;

    BuildManager buildManager;

    void Start()
    {
        ren = GetComponent<Renderer>();
        normalColor = ren.material.color;

        buildManager = BuildManager.instance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buildManager.GetTurretToBuild() == null)
        
            return;   
        
        ren.material.color = hoverColor;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
 
        ren.material.color = normalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (buildManager.GetTurretToBuild() == null) {
            return;
        }

        if (turret != null) {
            Debug.Log("Can't build there!");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }
}
