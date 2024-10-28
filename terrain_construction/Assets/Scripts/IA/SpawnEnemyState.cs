using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "SpawnState (S)", menuName = "ScriptableObject/States/SpawnStates")]
public class SpawnEnemyState : State
{
    public GameObject enemyPrefab;
    public override State Run(GameObject owner)
    {
        Instantiate(enemyPrefab, owner.transform.position, Quaternion.identity);

        
        return stateparameters[0].nextState;
    }
}
