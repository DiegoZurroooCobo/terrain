using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimePassedAction(A)", menuName = "ScriptableObject/Action/TimePassedAction")]

public class TimePassedAction : Action
{
    private float currentTime = 0;
    public float maxTime;
    public override bool Check(GameObject owner)
    {
        currentTime += Time.deltaTime;

        if(currentTime >= maxTime) 
        { 
            currentTime = 0;
            return true;
        }

        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
        
    }
}
