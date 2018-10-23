using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Eat")]
public class EatAction : AIAction
{
    public override void Act(StateController controller)
    {
        eatMeat(controller);
    }

    private void eatMeat(StateController controller)
    {
        if (controller.CheckIfCloseToFood(controller._raptorStats.eatingDistance))
        {
            controller.chaseTarget.gameObject.SetActive(false);
            Destroy(controller.chaseTarget.gameObject);
        }
    }
}
