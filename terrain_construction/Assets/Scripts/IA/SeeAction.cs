using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeeAction (A)", menuName = "ScriptableObject/Action/SeeAction")]

public class SeeAction : Action
{
    public override bool Check(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

    public override void DrawGizmos(GameObject owner)
    {
        throw new System.NotImplementedException();
    }
}
