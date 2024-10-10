using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    private State currentState;
    private HearAction actionDraw;
    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState; 
        actionDraw = GetComponent<HearAction>();    
    }

    // Update is called once per frame
    void Update()
    {
        State nextstate = currentState.Run(gameObject);

        if(nextstate) 
        { 
            currentState = nextstate; 
        }

        actionDraw.OnDrawGizmos(gameObject);
        
    }
    // llamarlo aqui el OnDrawGizmo
}
