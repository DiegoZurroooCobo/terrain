using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "GuardState (S)", menuName = "ScriptableObject/States/GuardStates")]

public class GuardState : State
{
    public Vector3 guardPoint; // un punto vector 3 donde la IA debe ir 

    public string blendParameter;

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator animator = navMeshAgent.GetComponent<Animator>();

        navMeshAgent.SetDestination(guardPoint); // la destinacion es el punto de guardia 
        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        
        return nextState; // se pasa al siguiente estado
    }
}
