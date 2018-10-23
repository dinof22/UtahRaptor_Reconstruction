using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Patrol")]
public class PatrollingAction : AIAction {

    public override void Act(StateController controller)
    {
        //throw new System.NotImplementedException();
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        controller._navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;

        //controller._navMeshAgent.Resume();
        controller._navMeshAgent.isStopped = false;

        if(controller._navMeshAgent.remainingDistance <= controller._navMeshAgent.stoppingDistance && !controller._navMeshAgent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }
}
