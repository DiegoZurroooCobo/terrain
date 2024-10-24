using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "SpawnRandomState (S)", menuName = "ScriptableObject/States/SpawnRandomStates")]
public class SpawnRandomState : State
{
    private float time = 0f;
    private int x= 45;
    private int z = 66;
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
        owner.transform.position = new Vector3(x, 1, z);

        return nextState;
    }
}
