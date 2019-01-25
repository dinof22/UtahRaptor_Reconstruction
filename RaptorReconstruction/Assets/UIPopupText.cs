using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class UIPopupText : VRTK_DestinationMarker {


    public GameObject infoSlab;
    public Transform waypointForAction;
    public RaptorAI raptor;

    //private bool lastUsePressedState = false;

    //private void OnTriggerEnter(Collider other)
    //{
    //    print("something is touching me");
    //    if (infoSlab.activeSelf)
    //    {
    //        infoSlab.SetActive(false);
    //        print(waypointForAction.name);
    //    }
    //    else
    //    {
    //        infoSlab.SetActive(true);
    //        print(waypointForAction.name);
    //        runActionForWayPoint();
    //        //make raptor do action of its waypoint
    //    }
    //}

    /*
    private void OnTriggerStay(Collider collider)
    {
        VRTK_ControllerEvents controller = (collider.GetComponent<VRTK_ControllerEvents>() ? collider.GetComponent<VRTK_ControllerEvents>() : collider.GetComponentInParent<VRTK_ControllerEvents>());
        if (controller != null)
        {
            if (lastUsePressedState == true && ! controller.triggerPressed)
            {
                if (infoSlab.activeSelf)
                {
                    infoSlab.SetActive(false);
                    print("poop");
                    print(waypointForAction.name);
                }
                else
                {
                    infoSlab.SetActive(true);
                    print("poop");
                    print(waypointForAction.name);
                    //make raptor do action of its waypoint
                }
            }
        }
    }
    */
    public void runActionForWayPoint()
    {
        switch (waypointForAction.name)
        {
            case "ScratchPoint":
                print("i must scratch");
                raptor.current_State = RaptorAI.states.Scratch;
                raptor.Scratch_State();
                break;
            case "EatPoint":
                print("i must eat");
                raptor.current_State = RaptorAI.states.Eat;
                raptor.Eat_State();
                break;
            case "DrinkPoint":
                print("i must drink");
                raptor.current_State = RaptorAI.states.Drink;
                raptor.Drink_State();
                break;
            default:
                print("this area has no action associated with it");
                break;
        }

    }



}
