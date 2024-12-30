using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private InputActionReference actionReference;
    private InputAction sprint;
    public PlayerMovementAdvanced pm;


    private void OnEnable()
    {
        actionReference.action.Enable();
    }
    private void OnDisable()
    {
        actionReference.action.Disable();
    }
    private void Start()
    {
        actionReference.action.started += context =>
        {
            
        };
    }
}
