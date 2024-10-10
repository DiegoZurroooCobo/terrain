using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct StateParameters
{
    [Tooltip("Indicates if the actions check must be true or false")]
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

    protected State CheckActions(GameObject owner)
    { 
        for (int i = 0; i < stateparameters.Length; i++) // recorre el array de los parametros del estado
        {
            if (stateparameters[i].actionValue == stateparameters[i].action.Check(owner))  // en cada vuelta, si el valor de la accion es igual a la accion que se va a realizar, se pasa a la siguiente accion
            { 
                return stateparameters[i].nextState; // devuelve la siguiente accion
            }
        }
        return null;   // ninguna accion se cumple, por lo que no cambiamos de estado
    }

    // comprueba si las acciones se cumplen y ademas
    // ejecuta el comportamiento asociado al estado
    public abstract State Run(GameObject owner);
}
