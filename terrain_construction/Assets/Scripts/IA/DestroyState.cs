using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "DestroyState (S)", menuName = "ScriptableObject/States/DestoyStates")]
public class DestroyState : State
{
    public override State Run(GameObject owner)
    {
        Destroy(owner);

        return null;
    }
}
