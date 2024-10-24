using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "WanderState (S)", menuName = "ScriptableObject/States/WanderStates")]

public class WanderState : State
{
    //public float wanderTimer;
    //public float wanderRadius;

    public float time = 0;

    public float range = 10000f;

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        if (Mathf.Approximately(navMeshAgent.remainingDistance, navMeshAgent.stoppingDistance))
            time -= Time.deltaTime;

        if (time <= 0f)
        {
            time = 5f;
            // bool pos = NavMesh.SamplePosition(owner.transform.position, out NavMeshHit hit, 100f, new NavMeshQueryFilter { agentTypeID = NavMesh.GetSettingsByIndex(0).agentTypeID, areaMask = NavMesh.AllAreas });
            Vector3 point;
            if (RandomPoint(owner.transform.position, range, out point))
            {
                navMeshAgent.SetDestination(point);
            }
        }

        return nextState;

    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result) 
    { 
        for(int i = 0; i < 30; i++) 
        { 
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1000.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

}

