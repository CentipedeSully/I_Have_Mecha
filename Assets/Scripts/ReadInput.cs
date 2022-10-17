using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private Vector2 _moveInput = Vector2.zero;
    private bool _shootInput = false;
    private bool _boostInput = false;





    public Vector2 GetMoveInput()
    {
        return _moveInput;
    }

    public bool GetShootInput()
    {
        return _shootInput;
    }

    public bool GetBoostInput()
    {
        return _boostInput;
    }






}
