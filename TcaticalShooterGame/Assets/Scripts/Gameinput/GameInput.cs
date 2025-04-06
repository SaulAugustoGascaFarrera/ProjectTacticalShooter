using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    public event EventHandler OnUnitMove;

    InputManager inputManager;


    private void Awake()
    {
        inputManager = new InputManager();
        inputManager.Unit.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputManager.Unit.MoveSelect.performed += MoveSelect_performed;
    }

    private void MoveSelect_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnUnitMove?.Invoke(this, EventArgs.Empty);  
    }

    
}
