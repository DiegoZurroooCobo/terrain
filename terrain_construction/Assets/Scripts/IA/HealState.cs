using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "HealState (S)", menuName = "ScriptableObject/States/HealStates")]

public class HealState : State
{
    public float currentTime = 0, maxTime;
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            GameManager.instance.SetLifes(GameManager.instance.GetLifes() + 20);
            currentTime = 0;
            maxTime = 8f;
        }

        return nextState;
    }
}
