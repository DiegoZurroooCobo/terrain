using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReference : MonoBehaviour
{
    public GameObject Target;

    public string gameObjectToFindName;

    private void Start()
    {
        if (gameObjectToFindName != "")
            Target = GameObject.Find(gameObjectToFindName);
    }
}
