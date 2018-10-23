using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour {

    public State currentState;
    public RaptorStats _raptorStats;
    public Transform eyes;
    public State remainState;



    [HideInInspector] public NavMeshAgent _navMeshAgent;
    public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    public float foodMeter = 1;



    private bool aiActive;




    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        setupAI(true, wayPointList);
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
            //3 is spherecast radius, fix when raptorstats is working
            Gizmos.DrawWireSphere(eyes.position, _raptorStats.lookSphereCastRadius);
        }
    }

    public void TransitionState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCloseToFood(float eatingDistance)
    {
        return (_navMeshAgent.remainingDistance <= eatingDistance);
    }

    private void OnExitState()
    {
        foodMeter = foodMeter + 1;
        //meatthing.destroy
    }
}

