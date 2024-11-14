using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "DamageState (S)", menuName = "ScriptableObject/States/DamageStates")]

public class DamageState : State
{
    public float currentTime = 0f, maxTime;
    public override State Run(GameObject owner)
    {
        State nextstate = CheckActions(owner);
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            GameManager.instance.SetLifes(GameManager.instance.GetLifes() - 1);
            currentTime = 0f;
            maxTime = 3f;
        }

        return nextstate;
    }

}
