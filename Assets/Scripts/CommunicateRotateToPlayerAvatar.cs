using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicateRotateToPlayerAvatar : MonoBehaviour
{
    private Vector2 _turnInput = Vector2.zero;
    private Vector3 _rotateInstruction = Vector3.zero;

    [SerializeField] private RotateObject _playerRotateObjectScriptReference;

    private void Update()
    {
        BuildRotateInstructionsFromInputDetector();
        CommunicateRotateInstructionsToPlayerAvatar();
    }

    private void BuildRotateInstructionsFromInputDetector()
    {
        _turnInput = InputDetector.Instance.GetTurnInput();

        _rotateInstruction = new Vector3(_turnInput.y,_turnInput.x,0);
    }

    private void CommunicateRotateInstructionsToPlayerAvatar()
    {
        _playerRotateObjectScriptReference.setRotationInstruction(_rotateInstruction);
    }

}
