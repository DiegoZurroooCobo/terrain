using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionPoints : MonoBehaviour
{
    private float currentTime = 0, MaxTime = 60f;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.GetComponent<PlayerMovement>()) // si el minion colisiona con el player 
        {
            GameManager.instance.SetScore(GameManager.instance.GetScore() + 1);
            Destroy(gameObject);
            // aumenta el farm en 1 y se destruye 
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= MaxTime) 
        { 
            currentTime = 0;
            Destroy(gameObject);
        }
        // si pasan 60 segundos, el minion se elimina
    }

}
