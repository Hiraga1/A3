using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputHandler inputManager;
    PlayerMovementAdvanced pm;
    private void Awake()
    {
        inputManager = GetComponent<InputHandler>();
        pm = GetComponent<PlayerMovementAdvanced>();
    }
    private void Update()
    {
        inputManager.HandleAllInputs();
    }
    private void FixedUpdate()
    {
        pm.HandleAllMovement();
    }
}
