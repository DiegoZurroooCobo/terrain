using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "SpawnRandomState (S)", menuName = "ScriptableObject/States/SpawnRandomStates")]
public class SpawnRandomState : State
{
    private float time = 0f;
    public override State Run(GameObject owner)
    {
        time = Time.deltaTime;
        State nextState = CheckActions(owner);
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();

        if (time >= 5f)
        {
            navMeshAgent.SetDestination(new Vector3(Random.Range(0, 50), 0, Random.Range(50, 100)));
        }
        time = 0f;

        return nextState;
    }
}
