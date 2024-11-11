using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "HealState (S)", menuName = "ScriptableObject/States/HealStates")]

public class HealState : State
{
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);


            GameManager.instance.SetLifes(GameManager.instance.GetLifes() + 1);


        return nextState;
    }
}
