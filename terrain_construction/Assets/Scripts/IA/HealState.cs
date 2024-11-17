using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "HealState (S)", menuName = "ScriptableObject/States/HealStates")]

public class HealState : State  // estado de curar 
{
    public float currentTime = 0, maxTime;
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner); // el siguiente estado 
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime) // cooldown de la habilidad. cuando el tiempo actual supera al maximo
        {
            GameManager.instance.SetLifes(GameManager.instance.GetLifes() + 3); // la vida del GameManager sube en 3
            currentTime = 0;
            maxTime = 8f;
        }

        return nextState; // se pasa al siguiente estado
    }
}
