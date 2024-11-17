using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[CreateAssetMenu(fileName = "HearAction(A)", menuName = "ScriptableObject/Action/HearAction")]

public class HearAction : Action
{
    public float radius = 20f; 
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius, Vector3.up); // castea una esfera

        GameObject target = owner.GetComponent<TargetReference>().Target; // accedemos al target 

        foreach(RaycastHit hit in hits) // por cada hit en el array de hits
        { 
            if(hit.collider.gameObject == target) // recorremos todos los objetos que estamos escuchando es el objetivo
            {
                return true; // le ha escuchado. Devuelve true
            }
        }
        return false; // no le esucho
    }

    public override void DrawGizmos(GameObject owner) // se dibuja la esfera 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(owner.transform.position, radius);
    }
}
