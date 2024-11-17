using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeeAction(A)", menuName = "ScriptableObject/Action/SeeAction")]

public class SeeAction : Action
{
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<TargetReference>().Target;
        ColliderCono collidercono = owner.GetComponentInChildren<ColliderCono>(); // recorre los componentes de sus hijos
        List<GameObject> visionList = collidercono.GetVisionList(); // nueva lista que se iguala a la lista del collider
        foreach (GameObject gameobjectInVision in visionList) // por cada objeto en vision en la lista
        { 
            if(gameobjectInVision == target) 
            { 
                return true;
            }
        }
        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {

    }
}

