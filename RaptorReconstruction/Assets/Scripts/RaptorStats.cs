using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "PluggableAI/RaptorStats")]
public class RaptorStats : ScriptableObject
{
    public  float lookSphereCastRadius = 20f;
    public float moveSpeed = 3;
    public float lookRange = 40f;

    public float eatingDistance = 4f;
}