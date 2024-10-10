using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    // la accion no se puedde implementar 
    public abstract bool Check(GameObject owner); // ejecutar el comportamiento de la accion

    // metodo abstracto de dibujar gizmo 

    public abstract void OnDrawGizmos();
}
