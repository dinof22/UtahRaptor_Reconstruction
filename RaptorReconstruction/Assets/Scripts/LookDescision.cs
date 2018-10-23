using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Descisions/Look")]
public class LookDescision : Descision {

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller._raptorStats.lookRange, Color.green);

        //3 is the sphere case radius, fix it when you get raptorstats working
        if (Physics.SphereCast(controller.eyes.position, controller._raptorStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller._raptorStats.lookRange) && hit.collider.CompareTag("Meat"))
        {
            controller.chaseTarget = hit.transform;
            return true;
        }
        else
        {
            return false;
        }
    }
}
