using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionPoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            GameManager.instance.SetScore(GameManager.instance.GetScore() + 1);
            Destroy(gameObject);
        }
    }
    
}
