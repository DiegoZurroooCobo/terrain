using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReference : MonoBehaviour
{
    public GameObject Target;

    public string gameObjectToFindName;

    private void Start()
    {
        if (gameObjectToFindName != "") // si el gameobject que buscamos es diferente del string que tenemos en el inspector
            Target = GameObject.Find(gameObjectToFindName); // target busca el gameobject que tiene que buscar 
    }
}
