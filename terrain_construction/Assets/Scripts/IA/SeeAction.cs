using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeeAction(A)", menuName = "ScriptableObject/Action/SeeAction")]

public class SeeAction : Action
{
    public float vision; // el angulo que tiene de vision
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
        //Vector3 dir = target.transform.position - owner.transform.forward; // la direccion que va a tener la vista. la posicion del target menos las posicion del enemigo
        //float angle = Vector3.Angle(dir, owner.transform.forward); // devuelve el angulo de los dos vectores. El angulo de vision
        //Debug.DrawRay(owner.transform.position + owner.transform.up, dir); // dibujo un rayo con la direccion en la que esta mirando

        //if (angle < vision * 0.5f) // si el angulo de vision que ve es menor al angulo de vision que tiene
        //{
        //    RaycastHit hit; // si hace un raycast

        //    if (Physics.Raycast(owner.transform.position + owner.transform.up, dir.normalized, out hit, 20f)) // el raycast 
        //    {
        //        if (hit.collider.gameObject == target) // si el raycast colisiona con el target deveulve true
        //        {
        //            return true;
        //        }
        //    }
        //}
        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {

    }
}

