using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveViewByMouseInput : MonoBehaviour
{
    private Vector2 _mouseInput = Vector2.zero;
    private Vector3 _rotationInstruction = Vector3.zero;
    [SerializeField] private RotateThisAroundObject _viewRotateAroundObjectScript;

    private void Update()
    {
        BuildRotateInstructionsFromInput();
        CommunicateInstructionsToRotationScript();
    }


    private void BuildRotateInstructionsFromInput()
    {
        //Invert Rotate Instructions.
        _rotationInstruction = new Vector3(_mouseInput.x, _mouseInput.y);

        _rotationInstruction = -1 * _rotationInstruction;
    }

    private void CommunicateInstructionsToRotationScript()
    {
        _viewRotateAroundObjectScript.setRotationInstruction(_rotationInstruction);
    }
}
