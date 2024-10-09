using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StateParameters
{
    [Tooltip("Indicates if the action�s check must be true or false")]
    public bool actionValue;
    [Tooltip("Action that is gonna be executed")]
    public Action action;
    [Tooltip("if the actions check equals actionsValue, nextState is pushed")]
    public State nextState;
}
public abstract class State : ScriptableObject
{

    public StateParameters[] stateparameters;

    // Action [] actions
    // [CreateAssetMenu()]

    private State CheckActions(GameObject owner)
    {
        for (int i = 0; i < stateparameters.Length; i++)
        {
            if (stateparameters[i].actionValue == stateparameters[i].action.Check(owner))  
            { 
                return stateparameters[i].nextState;
            }
        }
        return null;   
    }
    public abstract State Run(GameObject owner);
}
