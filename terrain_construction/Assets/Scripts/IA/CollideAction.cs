using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollisionAction(A)", menuName = "ScriptableObject/Action/CollisionAction")]

public class CollideAction : Action
{
    public GameObject target;
    public override bool Check(GameObject owner)
    {
       return true;
    }

    public override void DrawGizmos(GameObject owner)
    {
        throw new System.NotImplementedException();
    }
}
