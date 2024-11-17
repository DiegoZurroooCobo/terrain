using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionPoints : MonoBehaviour
{
    private float currentTime = 0, MaxTime = 60f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            GameManager.instance.SetScore(GameManager.instance.GetScore() + 1);
            Destroy(gameObject);
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
    }

}
