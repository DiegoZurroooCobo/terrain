using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float speed, runningSpeed, rotationSpeed, gravityScale, jumpForce;

    private float yVelocity = 0, currentspeed;
    private CharacterController characterController;
    private Vector3 auxMovementVector;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravityScale = Mathf.Abs(gravityScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            yVelocity = 0;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);
        float mouseX = Input.GetAxis("Mouse X");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

        Jump(jumpPressed);
        Movement(x, z, shiftPressed);
        //Rotation(mouseX);
    }

    void Jump(bool jumpPressed)
    {
        if (jumpPressed && characterController.isGrounded)
        {
            yVelocity += Mathf.Sqrt(jumpForce * 3 * gravityScale); // raiz cuadrada que suaviza el salto
        }
    }

    void Movement(float x, float z, bool shiftPressed)
    {
        if (shiftPressed)
        {
            currentspeed = runningSpeed;
        }
        else
        {
            currentspeed = speed;
        }
        Vector3 movementVector = transform.forward * currentspeed * z + transform.right * currentspeed * x;
        auxMovementVector = movementVector;

        yVelocity -= gravityScale;

        movementVector.y = yVelocity;

        movementVector *= Time.deltaTime; // se mueve igual si importar el framerate
        characterController.Move(movementVector); // metodo de character controller para moverlo
    }

    public Vector3 GetMovementVector()
    {
        return auxMovementVector;
    }

    void Rotation(float mouseX)
    {
        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation); // el transform rote a la rotacion a la que estamos moviendo
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<NavMeshAgent>())
        {
            GameManager.instance.SetLifes(GameManager.instance.GetLifes() - 1);
        }
    }
}
