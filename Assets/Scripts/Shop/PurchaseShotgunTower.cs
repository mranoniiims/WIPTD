using UnityEngine;
using UnityEngine.EventSystems;



public class PurchaseShotgunTower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    private Color normalColor;
    public Color hoverColor;

    private Renderer ren;

    void Start()
    {
        ren = GetComponent<Renderer>();
        normalColor = ren.material.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ren.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        ren.material.color = normalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Shop.instance.PurchaseShotgunTurret();
    }

}