using UnityEngine;
using UnityEngine.EventSystems;

public class StartPillar : MonoBehaviour, IPointerClickHandler
{
    public GameObject startGameObjects;
    public GameObject startPillar;
    public void OnPointerClick(PointerEventData eventData)
    {
        startGameObjects.SetActive(true);
        startPillar.SetActive(false);
        
    }

}
