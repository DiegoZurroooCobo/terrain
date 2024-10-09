using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    private State currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
