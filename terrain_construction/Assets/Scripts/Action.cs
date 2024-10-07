using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    // la accion no se puedde implementar 
    public abstract bool Check(GameObject owner); // ejecutar el comportamiento de la accion
}
