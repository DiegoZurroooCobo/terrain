using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "WanderState (S)", menuName = "ScriptableObject/States/WanderStates")]

public class WanderState : State
{
    public float wanderTimer;
    public float wanderRadius;

    private Transform target;
    private float time;
    private int x;
    private int z;

    private void OnEnable()
    {
        time = wanderTimer;
    }
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        time += Time.deltaTime;

        if (time >= 5f)
        {
            x = Random.Range(0, 51);
            z = Random.Range(50, 101);
            time = 0f;
        }
        navMeshAgent.SetDestination(new Vector3(x, 0, z));

        return nextState;

    }

}

