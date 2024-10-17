using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "HealState (H)", menuName = "ScriptableObject/States/HealStates")]

public class HealState : State
{
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        GameObject target = owner.GetComponent<TargetReference>().Target;
        
        Collider collider = target.GetComponent<Collider>();
        if(collider) 
        {
            int life = GameManager.instance.GetLifes();
            GameManager.instance.SetLifes(life + 1);

            Destroy(this.GameObject());
        }
        return nextState;
    }
}
