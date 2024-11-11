using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DamageState (S)", menuName = "ScriptableObject/States/DamageStates")]

public class DamageState : State
{
    public override State Run(GameObject owner)
    {
        State nextstate = CheckActions(owner);

        GameManager.instance.SetLifes(GameManager.instance.GetLifes() - 1); 

        return nextstate;
    }

}
