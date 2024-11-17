using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "NearPointAction(A)", menuName = "ScriptableObject/Action/NearPointAction")]

public class NearPointAction : Action
{
    public override bool Check(GameObject owner)
    {
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        if (Mathf.Approximately(navMeshAgent.remainingDistance, navMeshAgent.stoppingDistance)) // si se esta acercando al stopping distance 
        {
            return true;

        }
        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
    }

}
