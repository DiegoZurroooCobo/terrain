using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState (S)", menuName = "ScriptableObject/States/ChaseStates")]

public class ChaseState : State
{
    public string blendParameter;

    public override State Run(GameObject owner)
    {


        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        GameObject target = owner.GetComponent<TargetReference>().Target;
        Animator animator = navMeshAgent.GetComponent<Animator>();

        navMeshAgent.SetDestination(target.transform.position); // setdestination le dice al agente "oye tu destino es el transform del objetivo" 
        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed);


        return nextState;
    }
}
