using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Descisions/ActiveState")]
public class ActiveStateDescision : Descision {

    public override bool Decide(StateController controller)
    {
        bool chaseTargetIsActive = controller.chaseTarget.gameObject.activeSelf;
        return chaseTargetIsActive;
    }
}
