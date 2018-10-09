using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour {

    [HideInInspector] public NavMeshAgent _navMeshAgent;
    [HideInInspector] public List<Transform> wayPointList;
}
