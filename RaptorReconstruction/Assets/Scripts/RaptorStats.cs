using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "PluggableAI/RaptorStats")]
public class RaptorStats : ScriptableObject
{
    public  float lookSphereCastRadius = 6f;
    public float moveSpeed = 2;
    public float lookRange = 6f;

    public float eatingDistance = 0.5f;
}