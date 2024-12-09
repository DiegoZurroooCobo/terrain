using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "FleeState (S)", menuName = "ScriptableObject/States/FleeStates")]

public class FleeState : State
{
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);
        TargetReference tReference = owner.GetComponent<TargetReference>();
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();

        Vector3 fleeAway = (owner.transform.position - tReference.Target.transform.position).normalized;
        navMeshAgent.SetDestination(owner.transform.position + fleeAway);

        return nextState;
    }

}
