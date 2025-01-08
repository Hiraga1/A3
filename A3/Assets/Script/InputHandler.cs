using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    Third_Person_View playerControls;

    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new Third_Person_View();

            playerControls.Player.Move.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    public void HandleAllInputs()
    {
        HandleMovementInput(); //Movement
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }
}
