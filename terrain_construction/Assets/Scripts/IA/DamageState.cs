using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "DamageState (S)", menuName = "ScriptableObject/States/DamageStates")]

public class DamageState : State // estado para hacer daño
{
    public float currentTime = 0f, maxTime;
    public override State Run(GameObject owner)
    {
        State nextstate = CheckActions(owner);
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime) // Cooldown del estado de daño. si el tiempo actual supera al tiempo maximo
        {
            GameManager.instance.SetLifes(GameManager.instance.GetLifes() - 1); // las vidas del gameManager bahan en 1
            currentTime = 0f;
            maxTime = 1f;
        }

        return nextstate; // se pasa al siguiente de la maquina de estados
    }

}
