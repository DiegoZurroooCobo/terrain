using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        //bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

        //if (x != 0 || z != 0) // se esta moviendo
        //{ 
        //    if(shiftPressed) 
        //    { 
        //        // ademas corre
        //        animator.SetBool("isRunning", true);
        //        animator.SetBool("isWalking", false);
        //    }
        //    else 
        //    { 
        //        // esta andando
        //        animator.SetBool("isWalking", true);
        //        animator.SetBool("isRunning", false);
        //    }
        //}
        //else 
        //{ 
        //    // esta quieto
        //    animator.SetBool("isWalking", false);
        //    animator.SetBool("isRunning", false);
        //}
    }

    private void LateUpdate()
    {
        animator.SetFloat("Speed", playerMovement.GetCurrentSpeed() / playerMovement.runningSpeed); 
    }
}
