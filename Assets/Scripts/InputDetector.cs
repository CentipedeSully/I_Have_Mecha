using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SullysToolkit.Abstracts;


public class InputDetector : MonoSingleton<InputDetector>
{
    private Vector2 _moveInput;
    [SerializeField]
    private Vector2 _turnInput;
    private bool _shootInput = false;
    private bool _boostInput = false;


    protected override void InitializeAdditionalFields()
    {
        _moveInput = Vector2.zero;
        _turnInput = Vector2.zero;
    }



    public Vector2 GetMoveInput()
    {
        return _moveInput;
    }

    public Vector2 GetTurnInput()
    {
        return _turnInput;
    }

    public bool GetShootInput()
    {
        return _shootInput;
    }

    public bool GetBoostInput()
    {
        return _boostInput;
    }





    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            _moveInput = context.ReadValue<Vector2>();
        }
        else _moveInput = Vector2.zero;
    }

    public void ReadTurnInput(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            _turnInput = context.ReadValue<Vector2>();
        }
        else _turnInput = Vector2.zero;
    }

    public void ReadShootInput(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            _shootInput = true;
        }
        else _shootInput = false;
    }

    public void ReadBoostInput(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            _boostInput = true;
        }
        else _boostInput = false;
    }



}
