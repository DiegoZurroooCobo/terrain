using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBigEnemy : MonoBehaviour
{
    public GameObject BigEnemy;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Spwner")) 
        {
            Instantiate(BigEnemy);
        }
    }
}
