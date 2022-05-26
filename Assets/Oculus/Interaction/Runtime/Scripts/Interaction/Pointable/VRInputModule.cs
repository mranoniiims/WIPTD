using UnityEngine;
using UnityEngine.EventSystems;

//by Ralph Barbagallo
//www.flarb.com
//www.ralphbarbagallo.com
//@flarb

public class VRInputModule : BaseInputModule
{

    public static GameObject targetObject;

    static VRInputModule _singleton;

    private int counter;

    private static bool mouseClicked;
    public static Vector3 cursorPosition;
    
    void Awake()
    {
        _singleton = this;
    }

    public override void Process()
    {
        if (targetObject == null)
        {
            mouseClicked = false;
            return;
        }

        //    //Original code now replaced by PointerSubmit() below.  Works the same as far as I can see:
        //if (mouseClicked)
        //{
        //    //BaseEventData data = GetBaseEventData();
        //    BaseEventData data = new BaseEventData(_singleton.eventSystem);
        //    data.selectedObject = targetObject;
        //    ExecuteEvents.Execute(targetObject, data, ExecuteEvents.submitHandler);
        //    print("clicked " + targetObject.name);
        //    mouseClicked = false;
        //}
        //}
    }

    //public override bool IsPointerOverEventSystemObject(int pointerId)
    //{
    //    if (targetObject != null)
    //        return true;

    //    return false;
    //}

    public static void PointerSubmit(GameObject obj)
    {
        targetObject = obj;
        mouseClicked = true;
        if (mouseClicked)
        {
            //BaseEventData data = GetBaseEventData(); //Original from Process().  Can't be called here so is replaced by the next line:
            BaseEventData data = new BaseEventData(_singleton.eventSystem);
            data.selectedObject = targetObject;
            ExecuteEvents.Execute(targetObject, data, ExecuteEvents.submitHandler);
            print("clicked " + targetObject.name);
            mouseClicked = false;
            
        }

    }

    public static void PointerExit(GameObject obj)
    {
        print("PointerExit " + obj.name);
        PointerEventData pEvent = new PointerEventData(_singleton.eventSystem);
        ExecuteEvents.Execute(obj, pEvent, ExecuteEvents.pointerExitHandler);
        ExecuteEvents.Execute(obj, pEvent, ExecuteEvents.deselectHandler); //This fixes the problem
    }

    public static void PointerEnter(GameObject obj)
    {
        print("PointerEnter " + obj.name);
        PointerEventData pEvent = new PointerEventData(_singleton.eventSystem);
        pEvent.pointerEnter = obj;
        pEvent.worldPosition = cursorPosition;
        ExecuteEvents.Execute(obj, pEvent, ExecuteEvents.pointerEnterHandler);
    }

   
}