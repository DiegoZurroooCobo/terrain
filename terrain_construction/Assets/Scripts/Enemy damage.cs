using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>()) 
        { 
            GameManager.instance.SetLifes(GameManager.instance.GetLifes() - 1);
        }
    }
}
