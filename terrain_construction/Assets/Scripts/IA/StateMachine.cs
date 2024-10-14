using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    public State currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState; 
    }

    // Update is called once per frame
    void Update()
    {
        State nextstate = currentState.Run(gameObject);

        if(nextstate) 
        { 
            currentState = nextstate; 
        }
        
    }

    private void OnDrawGizmos()
    {
        if(currentState) //si el current state tiene informacion 
        {
            currentState.DrawAllActionsGizmos(gameObject); // llama al metodo de dibujar el gizmo desde le state
        }
        else // si no tiene nada 
        { 
            initialState.DrawAllActionsGizmos(gameObject); // llama al initialState
        }
    }
    // llamarlo aqui el OnDrawGizmo
}
