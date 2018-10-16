using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour {

    public State currentState;
    public RaptorStats _raptorStats;
    public Transform eyes;



    [HideInInspector] public NavMeshAgent _navMeshAgent;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;



    private bool aiActive;




    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    public void setupAI(bool aiActivationFromRaptorManager, List<Transform> wayPointsFromRaptorManager)
    {
        wayPointList = wayPointsFromRaptorManager;
        aiActive = aiActivationFromRaptorManager;
        if (aiActive)
        {
            _navMeshAgent.enabled = true;
        }
        else
        {
            _navMeshAgent.enabled = false;
        }
    }



    private void Update()
    {
        if (!aiActive)
            return;
        currentState.updateState(this);
    }
    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, 3);
            //Gizmos.DrawWireSphere(eyes.position, _raptorStats.lookSphereCastRadius);
        }
    }
}

